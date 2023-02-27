using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

/// <summary>
/// ゴールの種別
/// </summary>
public enum GoalType
{
    // うろつく
    Wander,

    // 防御
    Defence,

    // 攻撃
    Attack,
}

/// <summary>
/// 行動の基底クラス
/// </summary>
public class EnemyMovementBase
{
    public GoalType GoalType { get; protected set; }

    /// <summary>
    /// 報酬リスト
    /// </summary>
    public List<Reward> RewardProspects { get; protected set; }


    #region コンストラクタ

    public EnemyMovementBase() { }

    public EnemyMovementBase(GoalType goalType) : this(goalType, new List<Reward>()) { }

    public EnemyMovementBase(GoalType goalType, List<Reward> rewards)
    {
        GoalType = goalType;
        RewardProspects = rewards;
    }

    #endregion
}

/// <summary>
/// あたりをうろつくプラン
/// </summary>
public class PlanWander : EnemyMovementBase
{
    public PlanWander() : base(GoalType.Wander) { }
}

/// <summary>
/// パワーを得る
/// </summary>
public class PlanGetPower : EnemyMovementBase
{
    public PlanGetPower() : base(GoalType.GetPower)
    {
        var reward = new Reward(RewardType.Power, 0.1f);
        RewardProspects.Add(reward);
    }
}

/// <summary>
/// エネルギーを得る
/// </summary>
public class PlanGetEnergy : EnemyMovementBase
{
    public PlanGetEnergy() : base(GoalType.GetEnergy)
    {
        var reward = new Reward(RewardType.Enegy, 0.1f);
        RewardProspects.Add(reward);
    }
}

public class PlanAttackTarget : EnemyMovementBase
{
    public PlanAttackTarget() : base(GoalType.Attack, new List<Reward>()) { }
}

