using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy‚ÌUŒ‚‚Ì‹““®
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("“GUŒ‚‚ÌƒvƒŒƒnƒu")]
    [SerializeField, Tooltip("“GUŒ‚‚ÌƒvƒŒƒnƒu")] GameObject _enemyAttackPrefab;
    [SerializeField, Tooltip("‰½•b‚¨‚«‚ÉUŒ‚‚·‚é‚©")] float _atkInterval = 2f;
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
        Debug.Log("“G‚ÌUŒ‚");
    }
}
