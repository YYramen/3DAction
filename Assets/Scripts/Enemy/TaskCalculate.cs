using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCalculate<T> : CompositeTask<T> where T : EnemyAIBase
{
    // プランナー
    private ICharacter _planner;

    // 現在選択されているプラン
    private EnemyMovementBase _currentPlan;

    // 短期記憶しているオブジェクトを保持
    private List<EnemyMovementBase> _shortMemories = new List<EnemyMovementBase>();

    // 長期記憶しているオブジェクトを保持
    private List<EnemyMovementBase> _longMemories = new List<EnemyMovementBase>();


    /// <summary>
    /// 記憶しているすべてのオブジェクトを返す
    /// </summary>
    private List<EnemyMovementBase> AllMemories
    {
        get
        {
            List<EnemyMovementBase> allMemories = new List<EnemyMovementBase>();
            allMemories.AddRange(_shortMemories);
            allMemories.AddRange(_longMemories);
            return allMemories;
        }
    }

    #region Constructor

    // コンストラクタ
    public TaskCalculate(T owner) : base(owner)
    {
        // NOTE:
        // 他キャラのAIを作成する場合はBrainの派生クラスを作成し、
        // そちらのコンストラクタ内で、生成するプランナーを変更する
        _planner = new EnemyPersonality(owner);
    }

    #endregion


    #region Public members

    /// <summary>
    /// プランを記憶に保持
    /// </summary>
    /// <param name="planObject"></param>
    public void Memorize(MovementObject planObject)
    {
        // 重複しているプランは追加しない
        if (HasMemory(planObject))
        {
            return;
        }

        _shortMemories.Add(MakeMemory(planObject));
    }

    /// <summary>
    /// メモリコントロール
    /// すでに達成したプランなど、記憶から消すべきオブジェクトをリストから削除する
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
    /// プランリストから最適なプランを評価、取得する
    /// </summary>
    /// <returns></returns>
    EnemyMovementBase EvaluatePlans()
    {
        List<EnemyMovementBase> plans = EnumeratePlans();
        return _planner.Evaluate(plans);
    }

    /// <summary>
    /// 短期・長期記憶双方に保持しているプランを列挙する
    /// </summary>
    /// <returns></returns>
    List<EnemyMovementBase> EnumeratePlans()
    {
        var plans = new List<EnemyMovementBase>();
        foreach (var m in AllMemories)
        {
            plans.Add(m.Plan);
        }
        return plans;
    }

    /// <summary>
    /// プランに応じてゴールを選択する
    /// </summary>
    /// <param name="plan"></param>
    /// <returns></returns>
    ITask GetGoalByPlan(EnemyMovementBase plan)
    {
        switch (plan.GoalType)
        {
            // あたりを探し回る
            case GoalType.Wander:
                {
                    return new GoalWander<T>(_owner);
                }

            // 防御
            case GoalType.Defence:
                {
                    var memory = FindMemory(plan);
                    return new GoalGetItem<T>(_owner, memory.Target);
                }

            // 敵を攻撃
            case GoalType.Attack:
                {
                    var memory = FindMemory(plan);
                    return new GoalAttackTarget<T>(_owner, memory.Target);
                }
        }

        return new Task<T>(_owner);
    }

    /// <summary>
    /// 選択中のプランからプランを変更する
    /// </summary>
    /// <param name="newPlan"></param>
    void ChangePlan(EnemyMovementBase newPlan)
    {
        Debug.Log("Change plan to " + newPlan);

        _currentPlan = newPlan;
        RemoveAllSubgoals();

        var goal = GetGoalByPlan(newPlan);
        AddSubgoal(goal);
    }

    /// <summary>
    /// プランオブジェクトからメモリオブジェクトを生成する
    /// </summary>
    EnemyMovementBase MakeMemory(MovementObject movementObject)
    {
        var memory = new EnemyMovementBase(movementObject);
        return memory;
    }

    /// <summary>
    /// 対象プランから記憶オブジェクトを検索
    /// </summary>
    EnemyMovementBase FindMemory(EnemyMovementBase plan)
    {
        return AllMemories.Find(m => m.Plan == plan);
    }

    /// <summary>
    /// 記憶にあるプランか
    /// </summary>
    bool HasMemory(MovementObject movementObject)
    {
        var memory = AllMemories.Find(m => m.Plan == movementObject.Plan);
        return memory != null;
    }

    /// <summary>
    /// 記憶にあるメモリか
    /// </summary>
    bool HasMemory(EnemyMovementBase memory)
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

        // なにもないときにあたりを歩き回るプランを設定しておく
        var memory = new EnemyMovementBase();
        memory.Plan = new PlanWander();

        _longMemories.Add(memory);
    }

    public override Status Process()
    {
        ActivateIfInactive();

        EnemyMovementBase selectedPlan = EvaluatePlans();
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
