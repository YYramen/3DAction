using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のプランの基底クラス
/// </summary>
public class EnemyPlanBase
{
    /// <summary>
    /// ゴールのタイプ(プランの種類に相当する)
    /// </summary>
    public enum GoalType
    {
        Idle,
        Attack,
        Defence,
    }

    /// <summary>
    /// 何を目的とするかの種類
    /// </summary>
    public enum RewardType
    {
        Health,
        Stamina,
    }
}
