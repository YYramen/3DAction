using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃R�}���h�����s����N���X�B
/// </summary>
public class PlayerCommandController : MonoBehaviour
{
    public void DoublePunch()
    {
        Debug.Log("�_�u���p���`");
    }

    public void PunchKickCombo()
    {
        Debug.Log("�p���`�L�b�N�R���{");
    }

    public void KickPunchCombo()
    {
        Debug.Log("�L�b�N�p���`�R���{");
    }
}
