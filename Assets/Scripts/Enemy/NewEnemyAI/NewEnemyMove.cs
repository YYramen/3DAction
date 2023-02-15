using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の移動クラス
/// </summary>
public class NewEnemyMove : MonoBehaviour
{
    [Header("移動")]
    [SerializeField, Tooltip("移動速度")] float _enemyMoveSpeed = 5f;

    NewEnemyStatus _enemyStatus;

    private void Start()
    {
        _enemyStatus = new NewEnemyStatus();
    }

    void Update()
    {
        Judge(_enemyStatus.CurrentEnemyDifficulty, _enemyStatus.CurrentEnemyState);
    }

    void Judge(EnemyDifficulty enemyDifficulty, EnemyState enemyState)
    {
        switch (enemyDifficulty)
        {
            case EnemyDifficulty.Easy:
                EasyMove(enemyState);
                break;
            case EnemyDifficulty.Normal:
                NormalMove(enemyState);
                break;
            case EnemyDifficulty.Hard:
                HardMove(enemyState);
                break;
        }
    }

    public void EasyMove(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Offence:
                Debug.Log($"難易度Easy、難易度{enemyState}の敵の動き");
                break;

            case EnemyState.Defence:
                Debug.Log($"難易度Easy、難易度{enemyState}の敵の動き");
                break;
        }
    }

    public void NormalMove(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Offence:
                Debug.Log($"難易度Normal、難易度{enemyState}の敵の動き");
                break;

            case EnemyState.Defence:
                Debug.Log($"難易度Normal、難易度{enemyState}の敵の動き");
                break;
        }
    }

    public void HardMove(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Offence:
                Debug.Log($"難易度Hard、難易度{enemyState}の敵の動き");
                break;

            case EnemyState.Defence:
                Debug.Log($"難易度Hard、難易度{enemyState}の敵の動き");
                break;
        }
    }
}
