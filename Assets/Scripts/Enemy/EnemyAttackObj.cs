using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍U���v���n�u�Ɏg���U������̃R���|�[�l���g
/// </summary>
public class EnemyAttackObj : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�U�����󂯂�");
        }
    }
}
