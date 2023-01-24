using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̊�b�퓬�֌W
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [Header("���ʉ�")]
    [SerializeField, Tooltip("�p���`�̌��ʉ�")] AudioClip[] _punchSounds;
    [SerializeField, Tooltip("�L�b�N�̌��ʉ�")] AudioClip[] _kickSounds;

    [Header("�U�����̃R���C�_�[")]
    [SerializeField, Tooltip("�U�����̃R���C�_�[")] GameObject[] _colliders;

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
    /// ���͂��󂯕t����
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
        Debug.Log("�p���`�K�[�h");
    }

    void PlayerKickGuard()
    {
        Debug.Log("�L�b�N�K�[�h");
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
