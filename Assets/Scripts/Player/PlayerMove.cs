using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きを制御するコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField,Tooltip("移動速度")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("カメラの位置")] Transform _aimPos;
    [SerializeField] AxisState _vertical;
    [SerializeField] AxisState _horizontal;

    Animator _anim;
    int _hashFront = Animator.StringToHash("Front");
    int _hashSide = Animator.StringToHash("Side");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        InputMove();
    }

    /// <summary>
    /// 入力を受け付ける関数
    /// </summary>
    private void InputMove()
    {
        // 入力を受け付ける
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var dir = new Vector3(x, 0, z).normalized;
        _horizontal.Update(Time.deltaTime);
        _vertical.Update(Time.deltaTime);

        // 移動速度
        var velocity = _moveSpeed * dir;

        // キャラクターの向きを更新
        var hRotation = Quaternion.AngleAxis(_horizontal.Value, Vector3.up);
        var vRotation = Quaternion.AngleAxis(_vertical.Value, Vector3.right);
        transform.rotation = hRotation;
        _aimPos.localRotation = vRotation;

        // Animatorに値を反映
        _anim.SetFloat(_hashFront, velocity.z, 0.1f, Time.deltaTime);
        _anim.SetFloat(_hashSide, velocity.x, 0.1f, Time.deltaTime);
    }
}
