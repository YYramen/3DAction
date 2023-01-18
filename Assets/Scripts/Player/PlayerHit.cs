using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �v���C���[�̍U���������������̋���
/// </summary>
public class PlayerHit : MonoBehaviour
{
    [SerializeField, Tooltip("����ꂽ�Ƃ��̌��ʉ�")] AudioClip _hitClip;
    [SerializeField, Tooltip("�p�[�e�B�N��")] ParticleSystem _hitEffect;
    [SerializeField, Tooltip("�q�b�g�X�g�b�v�̎���")] float _hitStopTime = 0.2f;

    Animator _anim;
    AudioSource _audioSc;

    private void Start()
    {
        _audioSc = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�U������̃��C���[�ɓ��������特���o��
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _audioSc.PlayOneShot(_hitClip);
            Instantiate(_hitEffect, other.transform.position, Quaternion.identity);
            OnAttackHit();
            Debug.Log($"{this}���U�����ꂽ");
        }
    }

    public void OnAttackHit()
    {
        // ���[�V�������~�߂�
        _anim.speed = 0f;

        var seq = DOTween.Sequence();
        seq.SetDelay(_hitStopTime);
        // ���[�V�������ĊJ
        seq.AppendCallback(() => _anim.speed = 1f);
    }
}
