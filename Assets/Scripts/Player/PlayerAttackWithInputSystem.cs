using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Playerの攻撃や防御の挙動を制御する。入力にはInputSystemを使用する
/// </summary>
public class PlayerAttackWithInputSystem : MonoBehaviour
{
    [Header("効果音")]
    [SerializeField, Tooltip("パンチの効果音")] AudioClip[] _punchSounds;
    [SerializeField, Tooltip("キックの効果音")] AudioClip[] _kickSounds;

    [Header("攻撃時のコライダー")]
    [SerializeField, Tooltip("攻撃時のコライダー")] GameObject[] _colliders;

    [Header("参照用")]
    [SerializeField, Tooltip("InputSystem")] PlayerInput _input;

    Animator _anim;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        foreach (var collider in _colliders)
        {
            collider.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _input.onActionTriggered += OnPunch;
        _input.onActionTriggered += OnKick;
        _input.onActionTriggered += OnPunchGuard;
        _input.onActionTriggered += OnKickGuard;
    }

    private void OnDisable()
    {
        _input.onActionTriggered -= OnPunch;
        _input.onActionTriggered -= OnKick;
        _input.onActionTriggered -= OnPunchGuard;
        _input.onActionTriggered -= OnKickGuard;
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.action.name != "Punch")
        {
            return;
        }
        _anim.SetTrigger("Punch");
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (context.action.name != "Kick")
        {
            return;
        }
        _anim.SetTrigger("Kick");
    }

    public void OnPunchGuard(InputAction.CallbackContext context)
    {

    }

    public void OnKickGuard(InputAction.CallbackContext context)
    {

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
