using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの戦闘関係
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [Header("効果音")]
    [SerializeField, Tooltip("攻撃１の効果音")] AudioClip _atkOneSe;
    [SerializeField, Tooltip("攻撃２の効果音")] AudioClip _atkTwoSe;

    [Header("コンボ")]
    [SerializeField, Tooltip("コンボ受付時間")] float _comboTime = 0.4f;

    [Header("攻撃時のコライダー")]
    [SerializeField, Tooltip("攻撃時のコライダー")] GameObject[] _colliders;

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
    /// 入力を受け付ける
    /// </summary>
    private void InputAttack()
    {
        if (Input.GetButtonDown("Fire1") && _attackOne == false)
        {
            _attackOne = true;
            _anim.SetTrigger("Attack1");
            _audioSource.PlayOneShot(_atkOneSe);
            Debug.Log("攻撃１");
        }
        else if (Input.GetButtonDown("Fire1") && _attackOne == true)
        {
            _attackTwo = true;
            _anim.SetTrigger("Attack2");
            _audioSource.PlayOneShot(_atkTwoSe);
            Debug.Log("攻撃２");
        }
        else
        {
            _attackOne = false;
            _attackTwo = false;
        }
    }

    bool ComboReception(bool attackNum)
    {
        return !attackNum;
    }

    //-----↓AnimationEventで使う関数（攻撃判定のオンオフ）↓-----//
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
