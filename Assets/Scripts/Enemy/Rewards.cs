using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��V�^�C�v�B
/// �������V�́AHP�ƃX�^�~�i��2�^�C�v�B
/// </summary>
public enum RewardType
{
    // �G�l���M�[
    Enegy,

    // �U����
    Power,
}

/// <summary>
/// ��V�f�[�^
/// </summary>
public class Rewards
{
    public RewardType RewardType { get; private set; }
    public float Value { get; private set; }

    public Rewards(RewardType type, float value)
    {
        RewardType = type;
        Value = value;
    }
}