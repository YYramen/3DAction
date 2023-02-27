using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 報酬タイプ。
/// 得られる報酬は、HPとスタミナの2タイプ。
/// </summary>
public enum RewardType
{
    // エネルギー
    Enegy,

    // 攻撃力
    Power,
}

/// <summary>
/// 報酬データ
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