using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの基礎戦闘関係
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [Header("効果音")]
    [SerializeField, Tooltip("パンチの効果音")] AudioClip[] _punchSounds;
    [SerializeField, Tooltip("キックの効果音")] AudioClip[] _kickSounds;

    [Header("攻撃時のコライダー")]
    [SerializeField, Tooltip("攻撃時のコライダー")] GameObject[] _colliders;

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
        InputButton();
    }

    /// <summary>
    /// 入力を受け付ける
    /// </summary>
    private void InputButton()
    {
        if (Input.GetButtonDown("Punch"))
        {
            _anim.SetTrigger("Punch");
        }

        if (Input.GetButtonDown("Kick"))
        {
            _anim.SetTrigger("Kick");
        }

        if (Input.GetButton("PunchGuard"))
        {
            PlayerPunchGuard();
        }
        else if (Input.GetButton("KickGuard"))
        {
            PlayerKickGuard();
        }
    }

    void PlayerPunchGuard()
    {
        Debug.Log("パンチガード");
    }

    void PlayerKickGuard()
    {
        Debug.Log("キックガード");
    }

    //-----↓AnimationEventで使う関数（攻撃判定のオンオフ）↓-----//
    #region パンチ
    public void OnPunchOneCollider()
    {
        _colliders[0].SetActive(true);
    }

    public void OffPunchOneCollider()
    {
        _colliders[0].SetActive(false);
    }

    public void OnPunchTwoCollider()
    {
        _colliders[1].SetActive(true);
    }

    public void OffPunchTwoCollider()
    {
        _colliders[1].SetActive(false);
    }

    public void OnPunchThreeCollider()
    {
        _colliders[2].SetActive(true);
    }

    public void OffPunchThreeCollider()
    {
        _colliders[2].SetActive(false);
    }

    public void PlayPunchOneSound()
    {
        _audioSource.PlayOneShot(_punchSounds[0]);
    }

    public void PlayPunchTwoSound()
    {
        _audioSource.PlayOneShot(_punchSounds[1]);
    }

    public void PlayPunchThreeSound()
    {
        _audioSource.PlayOneShot(_punchSounds[2]);
    }
    #endregion

    #region キック
    public void OnKickOneCollider()
    {
        _colliders[3].SetActive(true);
    }

    public void OffKickOneCollider()
    {
        _colliders[3].SetActive(false);
    }

    public void OnKickTwoCollider()
    {
        _colliders[4].SetActive(true);
    }

    public void OffKickTwoCollider()
    {
        _colliders[4].SetActive(false);
    }

    public void OnKickThreeCollider()
    {
        _colliders[5].SetActive(true);
    }

    public void OffKickThreeCollider()
    {
        _colliders[5].SetActive(false);
    }

    public void PlayKickOneSound()
    {
        _audioSource.PlayOneShot(_kickSounds[0]);
    }

    public void PlayKickTwoSound()
    {
        _audioSource.PlayOneShot(_kickSounds[1]);
    }

    public void PlayKickThreeSound()
    {
        _audioSource.PlayOneShot(_kickSounds[2]);
    }
    #endregion
}
