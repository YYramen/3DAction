using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の攻撃プレハブに使う攻撃判定のコンポーネント
/// </summary>
public class EnemyAttackObj : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}
