using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍U���v���n�u�Ɏg���U������̃R���|�[�l���g
/// </summary>
public class EnemyAttackObj : MonoBehaviour
{
    [SerializeField, Tooltip("�I�u�W�F�N�g�̐�������")]
    private void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{other.name} ���U�����󂯂�");
        }
    }
}
