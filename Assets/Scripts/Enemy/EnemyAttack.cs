using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy�̍U���̋���
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("�G�U���̃v���n�u")]
    [SerializeField, Tooltip("�G�U���̃v���n�u")] GameObject _enemyAttackPrefab;
    [SerializeField, Tooltip("���b�����ɍU�����邩")] float _atkInterval = 2f;
    float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if( _timer > _atkInterval)
        {
            Attack();
            _timer = 0f;
        }
    }

    private void Attack()
    {
        Instantiate(_enemyAttackPrefab, this.transform);
        Debug.Log("�G�̍U��");
    }
}
