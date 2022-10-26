using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player‚Ìí“¬ŠÖŒW
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [Header("Œø‰Ê‰¹")]
    [SerializeField, Tooltip("UŒ‚‚P‚ÌŒø‰Ê‰¹")] AudioClip _atkOneSe;
    [SerializeField, Tooltip("UŒ‚‚Q‚ÌŒø‰Ê‰¹")] AudioClip _atkTwoSe;

    [Header("UŒ‚‚ÌƒRƒ‰ƒCƒ_[")]
    [SerializeField, Tooltip("UŒ‚‚ÌƒRƒ‰ƒCƒ_[")] GameObject[] _colliders;

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
    /// “ü—Í‚ğó‚¯•t‚¯‚é
    /// </summary>
    private void InputAttack()
    {
        if (Input.GetButtonDown("Fire1") && _attackOne == false)
        {
            _attackOne = true;
            _anim.SetTrigger("Attack1");
            _audioSource.PlayOneShot(_atkOneSe);
            Debug.Log("UŒ‚‚P");
        }
        else if (Input.GetButtonDown("Fire2") && _attackTwo == false)
        {
            _attackTwo = true;
            _anim.SetTrigger("Attack2");
            _audioSource.PlayOneShot(_atkTwoSe);
            Debug.Log("UŒ‚‚Q");
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
