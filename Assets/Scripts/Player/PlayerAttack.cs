using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̐퓬�֌W
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [Header("���ʉ�")]
    [SerializeField, Tooltip("�U���P�̌��ʉ�")] AudioClip _atkOneSe;
    [SerializeField, Tooltip("�U���Q�̌��ʉ�")] AudioClip _atkTwoSe;

    [Header("�U�����̃R���C�_�[")]
    [SerializeField, Tooltip("�U�����̃R���C�_�[")] GameObject[] _colliders;

    bool _attackOne;
    bool _attackTwo;

    Animator _anim;
    AudioSource _audioSource;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        foreach (var collider in _colliders)
        {
            collider.SetActive(false);
        }
    }

    private void Update()
    {
        InputAttack();
    }

    /// <summary>
    /// ���͂��󂯕t����
    /// </summary>
    private void InputAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _anim.SetTrigger("Attack");
        }
    }

    //-----��AnimationEvent�Ŏg���֐��i�U������̃I���I�t�j��-----//
    public void OnAttackOneCollider()
    {
        _colliders[0].SetActive(true);
    }

    public void OffAttackOneCollider()
    {
        _colliders[0].SetActive(false);
    }

    public void OnAttackTwoCollider()
    {
        _colliders[1].SetActive(true);
    }

    public void OffAttackTwoCollider()
    {
        _colliders[1].SetActive(false);
    }
}
