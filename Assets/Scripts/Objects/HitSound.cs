using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    [SerializeField, Tooltip("����ꂽ�Ƃ��̌��ʉ�")] AudioClip _hitClip;

    AudioSource _audioSc;

    private void Start()
    {
        _audioSc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            _audioSc.PlayOneShot(_hitClip);
            Debug.Log($"{this}���U�����ꂽ");
        }
        
    }
}
