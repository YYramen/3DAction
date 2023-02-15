using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃X�e�[�^�X
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�̗�")] int _playerHealth;
    [SerializeField, Tooltip("�X�^�~�i")] int _playerStamina;
    [SerializeField, Tooltip("�U����")] int _playerAttack;
    [SerializeField, Tooltip("�h���")] int _playerDefence;

    public int PlayerHealth { get => _playerHealth; }
    public int PlayerStamina { get => _playerStamina; set => _playerStamina = value; }
}
