using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �R�}���h
/// </summary>
public class PlayerCombat : MonoBehaviour
{
    [Header("�R���C�_�[")]
    [SerializeField, Tooltip("�p���`�̃R���C�_�[")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("�L�b�N�̃R���C�_�[")] SphereCollider[] _kickColliders;
    [Tooltip("�R�}���h�̔z��")] Input[] _inputs;
    
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            //AddInputs(Input.);
        }
    }

    void AddInputs(Input input)
    {
        
    }
}
