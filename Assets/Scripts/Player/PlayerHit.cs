using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// プレイヤーの攻撃が当たった時の挙動
/// </summary>
public class PlayerHit : MonoBehaviour
{
    [SerializeField, Tooltip("殴られたときの効果音")] AudioClip _hitClip;
    [SerializeField, Tooltip("パーティクル")] ParticleSystem _hitEffect;
    [SerializeField, Tooltip("ヒットストップの時間")] float _hitStopTime = 0.2f;

    Animator _anim;
    AudioSource _audioSc;

    private void Start()
    {
        _audioSc = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //攻撃判定のレイヤーに当たったら音を出す
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _audioSc.PlayOneShot(_hitClip);
            Instantiate(_hitEffect, other.transform.position, Quaternion.identity);
            OnAttackHit();
            Debug.Log($"{this}が攻撃された");
        }
    }

    public void OnAttackHit()
    {
        // モーションを止める
        _anim.speed = 0f;

        var seq = DOTween.Sequence();
        seq.SetDelay(_hitStopTime);
        // モーションを再開
        seq.AppendCallback(() => _anim.speed = 1f);
    }
}
