using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Tooltip("�p���`�K�[�h�t���O")] bool _pGuard;
    [Tooltip("�L�b�N�K�[�h�t���O")] bool _kGuard;

    [Header("�R���C�_�[")]
    [SerializeField, Tooltip("�p���`�̃R���C�_�[")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("�L�b�N�̃R���C�_�[")] SphereCollider[] _kickColliders;
}
