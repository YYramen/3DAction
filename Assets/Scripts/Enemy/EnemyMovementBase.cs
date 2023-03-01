using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Rewards> RewardProspects { get; protected set; }


    #region コンストラクタ

    public EnemyMovementBase() { }

    public EnemyMovementBase(GoalType goalType) : this(goalType, new List<Rewards>()) { }

    public EnemyMovementBase(GoalType goalType, List<Rewards> rewards)
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
/// 攻撃
/// </summary>
public class PlanGetPower : EnemyMovementBase
{
    public PlanGetPower() : base(GoalType.Defence)
    {
        var reward = new Rewards(RewardType.Power, 0.1f);
        RewardProspects.Add(reward);
    }
}

/// <summary>
/// 防御
/// </summary>
public class PlanGetEnergy : EnemyMovementBase
{
    public PlanGetEnergy() : base(GoalType.Attack)
    {
        var reward = new Rewards(RewardType.Enegy, 0.1f);
        RewardProspects.Add(reward);
    }
}

public class PlanAttackTarget : EnemyMovementBase
{
    public PlanAttackTarget() : base(GoalType.Attack, new List<Rewards>()) { }
}

