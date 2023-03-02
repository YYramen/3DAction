using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TaskCalculate<T> : CompositeTask<T> where T : EnemyAIBase
{
    // �v�����i�[
    private ICharacter _planner;

    // ���ݑI������Ă���v����
    private EnemyMovementBase _currentPlan;

    // �Z���L�����Ă���I�u�W�F�N�g��ێ�
    private List<MovementMemory> _shortMemories = new List<MovementMemory>();

    // �����L�����Ă���I�u�W�F�N�g��ێ�
    private List<MovementMemory> _longMemories = new List<MovementMemory>();


    /// <summary>
    /// �L�����Ă��邷�ׂẴI�u�W�F�N�g��Ԃ�
    /// </summary>
    private List<MovementMemory> AllMemories
    {
        get
        {
            List<MovementMemory> allMemories = new List<MovementMemory>();
            allMemories.AddRange(_shortMemories);
            allMemories.AddRange(_longMemories);
            return allMemories;
        }
    }

    #region Constructor

    // �R���X�g���N�^
    public TaskCalculate(T owner) : base(owner)
    {
        // NOTE:
        // ���L������AI���쐬����ꍇ��Brain�̔h���N���X���쐬���A
        // ������̃R���X�g���N�^���ŁA��������v�����i�[��ύX����
        _planner = new EnemyPersonality(owner);
    }

    #endregion


    #region Public members

    /// <summary>
    /// �v�������L���ɕێ�
    /// </summary>
    /// <param name="planObject"></param>
    public void Memorize(MovementObject planObject)
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
    /// �s�����X�g����œK�ȍs����]���A�擾����
    /// </summary>
    /// <returns></returns>
    EnemyMovementBase EvaluateMovements()
    {
        List<EnemyMovementBase> plans = EnumerateMovements();
        return _planner.Evaluate(plans);
    }

    /// <summary>
    /// �Z���E�����L���o���ɕێ����Ă���s����񋓂���
    /// </summary>
    /// <returns></returns>
    List<EnemyMovementBase> EnumerateMovements()
    {
        var plans = new List<EnemyMovementBase>();
        foreach (var m in AllMemories)
        {
            plans.Add(m.Movement);
        }
        return plans;
    }

    /// <summary>
    /// �s���ɉ����ăS�[����I������
    /// </summary>
    /// <param name="movements"></param>
    /// <returns></returns>
    ITask GetTaskByMovements(EnemyMovementBase movements)
    {
        switch (movements.MovementType)
        {
            // �����
            case MovementType.Wander:
                {
                    return new GoalWander<T>(_owner);
                }

            // �h��
            case MovementType.Defence:
                {
                    var memory = FindMemory(movements);
                    return new GoalGetItem<T>(_owner, memory.Target);
                }

            // �v���C���[���U��
            case MovementType.Attack:
                {
                    var memory = FindMemory(movements);
                    return new EnemyAttackTask<T>(_owner, memory.Target, memory.Position);
                }
        }

        return new Task<T>(_owner);
    }

    /// <summary>
    /// �I�𒆂̃v��������v������ύX����
    /// </summary>
    /// <param name="newMovements"></param>
    void ChangePlan(EnemyMovementBase newMovements)
    {
        Debug.Log("Change plan to " + newMovements);

        _currentPlan = newMovements;
        RemoveAllSubgoals();

        var goal = GetTaskByMovements(newMovements);
        AddSubgoal(goal);
    }

    /// <summary>
    /// �v�����I�u�W�F�N�g���烁�����I�u�W�F�N�g�𐶐�����
    /// </summary>
    MovementMemory MakeMemory(MovementObject movementObject)
    {
        var memory = new MovementMemory(movementObject);
        return memory;
    }

    /// <summary>
    /// �Ώۃv��������L���I�u�W�F�N�g������
    /// </summary>
    MovementMemory FindMemory(EnemyMovementBase movements)
    {
        return AllMemories.Find(m => m.Movement == movements);
    }

    /// <summary>
    /// �L���ɂ���v������
    /// </summary>
    bool HasMemory(MovementObject movementObject)
    {
        var memory = AllMemories.Find(m => m.Movement == movementObject.Movement);
        return memory != null;
    }

    /// <summary>
    /// �L���ɂ��郁������
    /// </summary>
    bool HasMemory(MovementMemory memory)
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

        // �Ȃɂ��Ȃ��Ƃ��ɂ������������s����ݒ肵�Ă���
        var memory = new MovementMemory();
        memory.Movement = new WanderMovement();

        _longMemories.Add(memory);
    }

    public override Status Process()
    {
        ActivateIfInactive();

        EnemyMovementBase selectedPlan = EvaluateMovements();
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
