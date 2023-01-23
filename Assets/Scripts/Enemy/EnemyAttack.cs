using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy‚ÌUŒ‚‚Ì‹““®
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("“GUŒ‚‚ÌƒvƒŒƒnƒu")]
    [SerializeField, Tooltip("“GUŒ‚‚ÌƒvƒŒƒnƒu")] GameObject[] _enemyAttackPrefab;
    [SerializeField, Tooltip("UŒ‚‚ÌêŠ")] Transform _attackPos;
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
        var random = Random.Range(0, _enemyAttackPrefab.Length);

        Instantiate(_enemyAttackPrefab[random],_attackPos.transform.position ,Quaternion.identity);
        Debug.Log("“G‚ÌUŒ‚");
    }
}
