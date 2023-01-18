using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の攻撃プレハブに使う攻撃判定のコンポーネント
/// </summary>
public class EnemyAttackObj : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトの生存時間")]
    private void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("攻撃を受けた");
        }
    }
}
