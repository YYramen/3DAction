using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̏��
/// </summary>
public enum EnemyState
{
    Offence = 1,
    Defence = 2,
}

/// <summary>
/// �G�̋���
/// </summary>
public enum EnemyDifficulty
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}

/// <summary>
/// �G�̃X�e�[�^�X
/// </summary>
public class NewEnemyStatus : MonoBehaviour
{
    [Header("�p�����[�^")]
    [SerializeField, Tooltip("�̗�")] int _enemyHealth = 5;
    [SerializeField, Tooltip("�X�^�~�i")] int _enemyStamina = 5;
    [SerializeField, Tooltip("�U����")] int _enemyAttack = 1;
    [SerializeField, Tooltip("�h���")] int _enemyDefence = 1;

    [Tooltip("���݂̓G�̋���")] EnemyDifficulty _currentEnemyDifficulty = EnemyDifficulty.Normal;
    [Tooltip("���݂̓G�̏��")] EnemyState _currentEnemyState = EnemyState.Offence;

    public EnemyDifficulty CurrentEnemyDifficulty { get => _currentEnemyDifficulty; set => _currentEnemyDifficulty = value; }
    public EnemyState CurrentEnemyState { get => _currentEnemyState; set => _currentEnemyState = value; }
}
