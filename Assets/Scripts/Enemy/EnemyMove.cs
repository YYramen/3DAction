using System.Collections;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 敵の動きを制御するコンポーネント
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Header("移動")]
    [SerializeField, Tooltip("プレイヤーの位置")] Transform _playerPos;
    [SerializeField, Tooltip("目的地")] Transform[] _wayPoints;
    [SerializeField, Tooltip("移動速度")] float _moveSpeed;

    [Header("参照用")]
    [SerializeField, Tooltip("EnemyDetectionコンポーネント")] EnemyDetection _enemyDetection;
    EnemyBehaviorType _behaviorType;

    /// <summary>
    /// "ほぼ"何もしない
    /// </summary>
    public void Idle()
    {
        Debug.Log($"{this.gameObject.name} は現在Idle状態");
    }

    /// <summary>
    /// 攻撃的に動く
    /// </summary>
    public void OffensiveMove()
    {
        Debug.Log($"{this.gameObject.name} は現在Offensive状態");
    }

    /// <summary>
    /// 守備的に動く
    /// </summary>
    private void DefenciveMove()
    {
        Debug.Log($"{this.gameObject.name} は現在Defencive状態");
    }
}