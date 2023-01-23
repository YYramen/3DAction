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

    [Header("コライダー")]
    [SerializeField, Tooltip("パンチのコライダー")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("キックのコライダー")] SphereCollider[] _kickColliders;


    private void Update()
    {
        InputButton();
    }

    void InputButton()
    {
        if (Input.GetButton("PunchGuard"))
        {
            Debug.Log("パンチガード");
            PunchGuard(_pGuard);
        }
        else if (Input.GetButton("KickGuard"))
        {
            Debug.Log("キックガード");
            KickGuard(_kGuard);
        }
        else
        {
            _pGuard = false;
            _kGuard = false;
        }
    }

    void TakePunchAttack()
    {

    }

    void TakeKickAttack()
    {

    }

    void PunchGuard(bool punchGuardFlag)
    {
        punchGuardFlag = true;
    }

    void KickGuard(bool kickGuardFlag)
    {
        kickGuardFlag = true;
    }
}
