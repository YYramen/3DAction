using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃X�e�[�^�X
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�̗�")] int _hp;
    [SerializeField, Tooltip("�X�^�~�i")] int _stamina;
    [SerializeField, Tooltip("�U����")] int _atk;
    [SerializeField, Tooltip("�h���")] int _def;

    void TakeDamage()
    {

    }
}
