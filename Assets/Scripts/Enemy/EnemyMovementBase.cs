using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行動の種別
/// </summary>
public enum MovementType
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
    public MovementType MovementType { get; protected set; }

    /// <summary>
    /// 報酬リスト
    /// </summary>
    public List<Rewards> RewardProspects { get; protected set; }

    #region コンストラクタ

    public EnemyMovementBase() { }

    public EnemyMovementBase(MovementType movementType) : this(movementType, new List<Rewards>()) { }

    public EnemyMovementBase(MovementType movementType, List<Rewards> rewards)
    {
        this.MovementType = movementType;
        RewardProspects = rewards;
    }

    #endregion
}

/// <summary>
/// うろつく
/// </summary>
public class WanderMovement : EnemyMovementBase
{
    public WanderMovement() : base(MovementType.Wander) { }
}

/// <summary>
/// 攻撃
/// </summary>
public class AttackMovement : EnemyMovementBase
{
    public AttackMovement() : base(MovementType.Attack)
    {
        var reward = new Rewards(RewardType.Power, 0.1f);
        RewardProspects.Add(reward);
    }
}

/// <summary>
/// 防御
/// </summary>
public class DefenceMovement : EnemyMovementBase
{
    public DefenceMovement() : base(MovementType.Defence)
    {
        var reward = new Rewards(RewardType.Enegy, 0.1f);
        RewardProspects.Add(reward);
    }
}

public class PlanAttackTarget : EnemyMovementBase
{
    public PlanAttackTarget() : base(MovementType.Attack, new List<Rewards>()) { }
}

