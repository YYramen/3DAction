using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("体力・スタミナ")]
    [SerializeField, Tooltip("体力")] int _hp;
    [SerializeField, Tooltip("スタミナ")] int _st;

    [Header("攻撃力")]
    [SerializeField, Tooltip("パンチの攻撃力")] int _punchAtk;
    [SerializeField, Tooltip("キックの攻撃力")] int _kickAtk;

    [Header("防御力")]
    [SerializeField, Tooltip("防御力")] int _guardPoint;
    [Tooltip("パンチガードフラグ")] bool _pGuard;
    [Tooltip("キックガードフラグ")] bool _kGuard;


}
