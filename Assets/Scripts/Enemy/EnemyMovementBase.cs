using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �S�[���̎��
/// </summary>
public enum GoalType
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
    public GoalType GoalType { get; protected set; }

    /// <summary>
    /// ��V���X�g
    /// </summary>
    public List<Rewards> RewardProspects { get; protected set; }


    #region �R���X�g���N�^

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
/// �������������v����
/// </summary>
public class PlanWander : EnemyMovementBase
{
    public PlanWander() : base(GoalType.Wander) { }
}

/// <summary>
/// �U��
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
/// �h��
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

