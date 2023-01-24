using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステータス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("体力")] int _hp;
    [SerializeField, Tooltip("スタミナ")] int _stamina;
    [SerializeField, Tooltip("攻撃力")] int _atk;
    [SerializeField, Tooltip("防御力")] int _def;

    void TakeDamage()
    {

    }
}
