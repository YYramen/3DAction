using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンド
/// </summary>
public class PlayerCombat : MonoBehaviour
{
    [Header("コライダー")]
    [SerializeField, Tooltip("パンチのコライダー")] SphereCollider[] _punchColliders;
    [SerializeField, Tooltip("キックのコライダー")] SphereCollider[] _kickColliders;
    [Tooltip("コマンドの配列")] Input[] _inputs;
    
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
