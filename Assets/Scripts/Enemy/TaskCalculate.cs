using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TaskCalculate<T> : CompositeTask<T> where T : EnemyAIBase
{
    // プランナー
    private ICharacter _planner;

    // 現在選択されているプラン
    private EnemyMovementBase _currentPlan;

    // 短期記憶しているオブジェクトを保持
    private List<MovementMemory> _shortMemories = new List<MovementMemory>();

    // 長期記憶しているオブジェクトを保持
    private List<MovementMemory> _longMemories = new List<MovementMemory>();


    /// <summary>
    /// 記憶しているすべてのオブジェクトを返す
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
    /// 行動リストから最適な行動を評価、取得する
    /// </summary>
    /// <returns></returns>
    EnemyMovementBase EvaluateMovements()
    {
        List<EnemyMovementBase> plans = EnumerateMovements();
        return _planner.Evaluate(plans);
    }

    /// <summary>
    /// 短期・長期記憶双方に保持している行動を列挙する
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
    /// 行動に応じてゴールを選択する
    /// </summary>
    /// <param name="movements"></param>
    /// <returns></returns>
    ITask GetTaskByMovements(EnemyMovementBase movements)
    {
        switch (movements.MovementType)
        {
            // うろつく
            case MovementType.Wander:
                {
                    return new GoalWander<T>(_owner);
                }

            // 防御
            case MovementType.Defence:
                {
                    var memory = FindMemory(movements);
                    return new GoalGetItem<T>(_owner, memory.Target);
                }

            // プレイヤーを攻撃
            case MovementType.Attack:
                {
                    var memory = FindMemory(movements);
                    return new EnemyAttackTask<T>(_owner, memory.Target, memory.Position);
                }
        }

        return new Task<T>(_owner);
    }

    /// <summary>
    /// 選択中のプランからプランを変更する
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
    /// プランオブジェクトからメモリオブジェクトを生成する
    /// </summary>
    MovementMemory MakeMemory(MovementObject movementObject)
    {
        var memory = new MovementMemory(movementObject);
        return memory;
    }

    /// <summary>
    /// 対象プランから記憶オブジェクトを検索
    /// </summary>
    MovementMemory FindMemory(EnemyMovementBase movements)
    {
        return AllMemories.Find(m => m.Movement == movements);
    }

    /// <summary>
    /// 記憶にあるプランか
    /// </summary>
    bool HasMemory(MovementObject movementObject)
    {
        var memory = AllMemories.Find(m => m.Movement == movementObject.Movement);
        return memory != null;
    }

    /// <summary>
    /// 記憶にあるメモリか
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

        // なにもないときにあたりを歩き回る行動を設定しておく
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
