using System.Collections;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �G�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Header("�ړ�")]
    [SerializeField, Tooltip("�v���C���[�̈ʒu")] Transform _playerPos;
    [SerializeField, Tooltip("�ړI�n")] Transform[] _wayPoints;
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed;

    [Header("�Q�Ɨp")]
    [SerializeField, Tooltip("EnemyDetection�R���|�[�l���g")] EnemyDetection _enemyDetection;
    EnemyBehaviorType _behaviorType;

    /// <summary>
    /// "�ق�"�������Ȃ�
    /// </summary>
    private void Idle()
    {

    }

    /// <summary>
    /// �U���I�ɓ���
    /// </summary>
    private void OffenciveMove()
    {
        
    }

    /// <summary>
    /// ����I�ɓ���
    /// </summary>
    private void DefenciveMove()
    {

    }
}