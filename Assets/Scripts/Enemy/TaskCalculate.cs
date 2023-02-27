using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCalculate<T> : CompositeTask<T> where T : EnemyAIBase
{
    // �v�����i�[
    private ICharacter _planner;

    // ���ݑI������Ă���v����
    private PlanBase _currentPlan;

    // �Z���L�����Ă���I�u�W�F�N�g��ێ�
    private List<Memory> _shortMemories = new List<Memory>();

    // �����L�����Ă���I�u�W�F�N�g��ێ�
    private List<Memory> _longMemories = new List<Memory>();

    /// <summary>
    /// �L�����Ă��邷�ׂẴI�u�W�F�N�g��Ԃ�
    /// </summary>
    private List<Memory> AllMemories
    {
        get
        {
            List<Memory> allMemories = new List<Memory>();
            allMemories.AddRange(_shortMemories);
            allMemories.AddRange(_longMemories);
            return allMemories;
        }
    }

    #region Constructor

    // �R���X�g���N�^
    public Brain(T owner) : base(owner)
    {
        // NOTE:
        // ���L������AI���쐬����ꍇ��Brain�̔h���N���X���쐬���A
        // ������̃R���X�g���N�^���ŁA��������v�����i�[��ύX����
        _planner = new CharaPlanner(owner);
    }

    #endregion


    #region Public members

    /// <summary>
    /// �v�������L���ɕێ�
    /// </summary>
    /// <param name="planObject"></param>
    public void Memorize(PlanObject planObject)
    {
        // �d�����Ă���v�����͒ǉ����Ȃ�
        if (HasMemory(planObject))
        {
            return;
        }

        _shortMemories.Add(MakeMemory(planObject));
    }

    /// <summary>
    /// �������R���g���[��
    /// ���łɒB�������v�����ȂǁA�L����������ׂ��I�u�W�F�N�g�����X�g����폜����
    /// </summary>
    public void MemoryControl()
    {
        var targets = from m in _shortMemories
                      where m.Target != null
                      select m;

        var newList = targets.ToList();
        _shortMemories = newList;
    }

    #endregion


    #region Private members

    /// <summary>
    /// �v�������X�g����œK�ȃv������]���A�擾����
    /// </summary>
    /// <returns></returns>
    PlanBase EvaluatePlans()
    {
        List<PlanBase> plans = EnumeratePlans();
        return _planner.Evaluate(plans);
    }

    /// <summary>
    /// �Z���E�����L���o���ɕێ����Ă���v������񋓂���
    /// </summary>
    /// <returns></returns>
    List<PlanBase> EnumeratePlans()
    {
        var plans = new List<PlanBase>();
        foreach (var m in AllMemories)
        {
            plans.Add(m.Plan);
        }
        return plans;
    }

    /// <summary>
    /// �v�����ɉ����ăS�[����I������
    /// </summary>
    /// <param name="plan"></param>
    /// <returns></returns>
    ITask GetGoalByPlan(PlanBase plan)
    {
        switch (plan.GoalType)
        {
            // �������T�����
            case GoalType.Wander:
                {
                    return new GoalWander<T>(_owner);
                }

            // �G�l���M�[�^�p���[�𓾂�
            case GoalType.GetEnergy:
            case GoalType.GetPower:
                {
                    var memory = FindMemory(plan);
                    return new GoalGetItem<T>(_owner, memory.Target);
                }

            // �G���U��
            case GoalType.Attack:
                {
                    var memory = FindMemory(plan);
                    return new GoalAttackTarget<T>(_owner, memory.Target);
                }
        }

        return new Goal<T>(_owner);
    }

    /// <summary>
    /// �I�𒆂̃v��������v������ύX����
    /// </summary>
    /// <param name="newPlan"></param>
    void ChangePlan(PlanBase newPlan)
    {
        Debug.Log("Change plan to " + newPlan);

        _currentPlan = newPlan;
        RemoveAllSubgoals();

        var goal = GetGoalByPlan(newPlan);
        AddSubgoal(goal);
    }

    /// <summary>
    /// �v�����I�u�W�F�N�g���烁�����I�u�W�F�N�g�𐶐�����
    /// </summary>
    Memory MakeMemory(PlanObject planObject)
    {
        var memory = new Memory(planObject);
        return memory;
    }

    /// <summary>
    /// �Ώۃv��������L���I�u�W�F�N�g������
    /// </summary>
    Memory FindMemory(PlanBase plan)
    {
        return AllMemories.Find(m => m.Plan == plan);
    }

    /// <summary>
    /// �L���ɂ���v������
    /// </summary>
    bool HasMemory(PlanObject planObject)
    {
        var memory = AllMemories.Find(m => m.Plan == planObject.Plan);
        return memory != null;
    }

    /// <summary>
    /// �L���ɂ��郁������
    /// </summary>
    bool HasMemory(Memory memory)
    {
        var storeMem = AllMemories.Find(m => m == memory);
        return storeMem != null;
    }

    #endregion


    #region Override Goal class

    public override void Activate()
    {
        base.Activate();

        RemoveAllSubgoals();

        // �Ȃɂ��Ȃ��Ƃ��ɂ������������v������ݒ肵�Ă���
        var memory = new Memory();
        memory.Plan = new PlanWander();

        _longMemories.Add(memory);
    }

    public override Status Process()
    {
        ActivateIfInactive();

        PlanBase selectedPlan = EvaluatePlans();
        bool needsChangePlan = (selectedPlan != null) && (_currentPlan != selectedPlan);
        if (needsChangePlan)
        {
            ChangePlan(selectedPlan);
        }

        return ProcessSubgoals();
    }

    public override void Terminate()
    {
        base.Terminate();
    }

    #endregion
}
