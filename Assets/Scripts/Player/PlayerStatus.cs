using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステータス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("体力")] int _playerHealth;
    [SerializeField, Tooltip("スタミナ")] int _playerStamina;
    [SerializeField, Tooltip("攻撃力")] int _playerAttack;
    [SerializeField, Tooltip("防御力")] int _playerDefence;

    public int PlayerHealth { get => _playerHealth; }
    public int PlayerStamina { get => _playerStamina; set => _playerStamina = value; }
}
