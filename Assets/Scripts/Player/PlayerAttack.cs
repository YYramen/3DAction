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
        if (Input.GetButtonDown("Fire1") && _attackOne == false)
        {
            _attackOne = true;
            _anim.SetTrigger("Attack1");
            _audioSource.PlayOneShot(_atkOneSe);
            Debug.Log("�U���P");
        }
        else if (Input.GetButtonDown("Fire2") && _attackTwo == false)
        {
            _attackTwo = true;
            _anim.SetTrigger("Attack2");
            _audioSource.PlayOneShot(_atkTwoSe);
            Debug.Log("�U���Q");
        }
        else
        {
            _attackOne = false;
            _attackTwo = false;
        }
    }

    public void OnAttackOneCollider()
    {
        _colliders[0].SetActive(true);
    }

    public void OffAttackOneCollider()
    {
        _colliders[0].SetActive(false);
    }
}
