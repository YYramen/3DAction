using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("�̗́E�X�^�~�i")]
    [SerializeField, Tooltip("�̗�")] int _hp;
    [SerializeField, Tooltip("�X�^�~�i")] int _st;

    [Header("�U����")]
    [SerializeField, Tooltip("�p���`�̍U����")] int _punchAtk;
    [SerializeField, Tooltip("�L�b�N�̍U����")] int _kickAtk;

    [Header("�h���")]
    [SerializeField, Tooltip("�h���")] int _guardPoint;
}