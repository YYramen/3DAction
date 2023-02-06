using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の行動パターン
/// </summary>
public enum EnemyBehaviorType
{
    Idle,
    Defence,
    Attack,
}

/// <summary>
/// 敵の強さ
/// </summary>
public enum EnemyLevel
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}

public class EnemyBehaviors : MonoBehaviour
{
    [Tooltip("現在のBehaviorType")] EnemyBehaviorType _currentType;

    public void SwitchType(EnemyBehaviorType type)
    {

    }
}
