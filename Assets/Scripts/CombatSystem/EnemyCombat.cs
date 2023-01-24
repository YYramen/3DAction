using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Tooltip("パンチガードフラグ")] bool _pGuard;
    [Tooltip("キックガードフラグ")] bool _kGuard;

    [Header("コライダー")]
    [SerializeField, Tooltip("パンチのコライダー")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("キックのコライダー")] SphereCollider[] _kickColliders;
}
