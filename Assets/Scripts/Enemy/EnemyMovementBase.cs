using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

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
    public List<Reward> RewardProspects { get; protected set; }


    #region �R���X�g���N�^

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
/// �������������v����
/// </summary>
public class PlanWander : EnemyMovementBase
{
    public PlanWander() : base(GoalType.Wander) { }
}

/// <summary>
/// �p���[�𓾂�
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
/// �G�l���M�[�𓾂�
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

