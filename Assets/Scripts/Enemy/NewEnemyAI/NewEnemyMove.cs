using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̈ړ��N���X
/// </summary>
public class NewEnemyMove : MonoBehaviour
{
    [Header("�ړ�")]
    [SerializeField, Tooltip("�ړ����x")] float _enemyMoveSpeed = 5f;

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
                Debug.Log($"��ՓxEasy�A��Փx{enemyState}�̓G�̓���");
                break;

            case EnemyState.Defence:
                Debug.Log($"��ՓxEasy�A��Փx{enemyState}�̓G�̓���");
                break;
        }
    }

    public void NormalMove(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Offence:
                Debug.Log($"��ՓxNormal�A��Փx{enemyState}�̓G�̓���");
                break;

            case EnemyState.Defence:
                Debug.Log($"��ՓxNormal�A��Փx{enemyState}�̓G�̓���");
                break;
        }
    }

    public void HardMove(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Offence:
                Debug.Log($"��ՓxHard�A��Փx{enemyState}�̓G�̓���");
                break;

            case EnemyState.Defence:
                Debug.Log($"��ՓxHard�A��Փx{enemyState}�̓G�̓���");
                break;
        }
    }
}
