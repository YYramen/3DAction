using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の状態
/// </summary>
public enum EnemyState
{
    Offence = 1,
    Defence = 2,
}

/// <summary>
/// 敵の強さ
/// </summary>
public enum EnemyDifficulty
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}

/// <summary>
/// 敵のステータス
/// </summary>
public class NewEnemyStatus : MonoBehaviour
{
    [Header("パラメータ")]
    [SerializeField, Tooltip("体力")] int _enemyHealth = 5;
    [SerializeField, Tooltip("スタミナ")] int _enemyStamina = 5;
    [SerializeField, Tooltip("攻撃力")] int _enemyAttack = 1;
    [SerializeField, Tooltip("防御力")] int _enemyDefence = 1;

    [Tooltip("現在の敵の強さ")] EnemyDifficulty _currentEnemyDifficulty = EnemyDifficulty.Normal;
    [Tooltip("現在の敵の状態")] EnemyState _currentEnemyState = EnemyState.Offence;

    public EnemyDifficulty CurrentEnemyDifficulty { get => _currentEnemyDifficulty; set => _currentEnemyDifficulty = value; }
    public EnemyState CurrentEnemyState { get => _currentEnemyState; set => _currentEnemyState = value; }
}
