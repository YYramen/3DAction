using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("�̗́E�X�^�~�i")]
    [SerializeField, Tooltip("�̗�")] int _hp;
    [SerializeField, Tooltip("�X�^�~�i")] int _st;

    [Header("�U����")]
    [SerializeField, Tooltip("�p���`�̍U����")] int _punchAtk;
    [SerializeField, Tooltip("�L�b�N�̍U����")] int _kickAtk;

    [Header("�h���")]
    [SerializeField, Tooltip("�h���")] int _guardPoint;
    [Tooltip("�p���`�K�[�h�t���O")] bool _pGuard;
    [Tooltip("�L�b�N�K�[�h�t���O")] bool _kGuard;

    [Header("�R���C�_�[")]
    [SerializeField, Tooltip("�p���`�̃R���C�_�[")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("�L�b�N�̃R���C�_�[")] SphereCollider[] _kickColliders;


    private void Update()
    {
        InputButton();
    }

    void InputButton()
    {
        if (Input.GetButton("PunchGuard"))
        {
            Debug.Log("�p���`�K�[�h");
            PunchGuard(_pGuard);
        }
        else if (Input.GetButton("KickGuard"))
        {
            Debug.Log("�L�b�N�K�[�h");
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
