using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃が当たった時の音
/// </summary>
public class HitSound : MonoBehaviour
{
    [SerializeField, Tooltip("殴られたときの効果音")] AudioClip _hitClip;
    AudioSource _audioSc;

    private void Start()
    {
        _audioSc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //攻撃判定のレイヤーに当たったら音を出す
        if (other.gameObject.layer == 7) 
        {
            _audioSc.PlayOneShot(_hitClip);
            Debug.Log($"{this}が攻撃された");
        }
    }
}
