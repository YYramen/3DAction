using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �s���̎��
/// </summary>
public enum MovementType
{
    // �����
    Wander,

    // �h��
    Defence,

    // �U��
    Attack,
}

/// <summary>
/// �s���̊��N���X
/// </summary>
public class EnemyMovementBase
{
    public MovementType MovementType { get; protected set; }

    /// <summary>
    /// ��V���X�g
    /// </summary>
    public List<Rewards> RewardProspects { get; protected set; }

    #region �R���X�g���N�^

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
/// �����
/// </summary>
public class WanderMovement : EnemyMovementBase
{
    public WanderMovement() : base(MovementType.Wander) { }
}

/// <summary>
/// �U��
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
/// �h��
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

