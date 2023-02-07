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
    public void Idle()
    {
        Debug.Log($"{this.gameObject.name} �͌���Idle���");
    }

    /// <summary>
    /// �U���I�ɓ���
    /// </summary>
    public void OffensiveMove()
    {
        Debug.Log($"{this.gameObject.name} �͌���Offensive���");
    }

    /// <summary>
    /// ����I�ɓ���
    /// </summary>
    private void DefenciveMove()
    {
        Debug.Log($"{this.gameObject.name} �͌���Defencive���");
    }
}