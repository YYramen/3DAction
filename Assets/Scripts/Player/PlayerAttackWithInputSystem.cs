using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player�̍U����h��̋����𐧌䂷��B���͂ɂ�InputSystem���g�p����
/// </summary>
public class PlayerAttackWithInputSystem : MonoBehaviour
{
    [Header("���ʉ�")]
    [SerializeField, Tooltip("�p���`�̌��ʉ�")] AudioClip[] _punchSounds;
    [SerializeField, Tooltip("�L�b�N�̌��ʉ�")] AudioClip[] _kickSounds;

    [Header("�U�����̃R���C�_�[")]
    [SerializeField, Tooltip("�U�����̃R���C�_�[")] GameObject[] _colliders;

    [Header("�Q�Ɨp")]
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

    //-----��AnimationEvent�Ŏg���֐��i�U������̃I���I�t�j��-----//
    #region �p���`
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

    #region �L�b�N
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
