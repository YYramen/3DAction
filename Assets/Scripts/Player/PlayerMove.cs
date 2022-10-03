using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�_�b�V����")] float _dashPower = 5.0f;
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed = 1.0f;
    [SerializeField, Tooltip("�W�����v��")] float _jumpPower = 5.0f;

    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _aimPos;
    [SerializeField] AxisState _vertical;
    [SerializeField] AxisState _horizontal;

    Rigidbody _rb;
    Animator _anim;
    int _hashFront = Animator.StringToHash("Front");
    int _hashSide = Animator.StringToHash("Side");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
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
    /// ���͎󂯕t���A�ړ����x�A�A�j���[�^�[�֐�
    /// �ړ����@�� Velocity �ōs��
    /// </summary>
    private void InputMove()
    {
        // ���͂��󂯕t����
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        var dir = new Vector3(x, 0, z).normalized;
        _horizontal.Update(Time.deltaTime);
        _vertical.Update(Time.deltaTime);

        // �ړ����x
        var velocity = _moveSpeed * dir;

        // �L�����N�^�[�̌������X�V
        var hRotation = Quaternion.AngleAxis(_horizontal.Value, Vector3.up);
        var vRotation = Quaternion.AngleAxis(_vertical.Value, Vector3.right);
        transform.rotation = hRotation;
        _aimPos.localRotation = vRotation;

        // Animator�ɒl�𔽉f
        _anim.SetFloat(_hashFront, velocity.z, 0.1f, Time.deltaTime);
        _anim.SetFloat(_hashSide, velocity.x, 0.1f, Time.deltaTime);

        // �_�b�V��
        if (Input.GetButtonDown("Dash"))
        {
            Dash(dir);
        }
    }

    /// <summary>
    /// �_�b�V��
    /// </summary>
    /// <param name="dir">�_�b�V���̕���</param>
    private void Dash(Vector3 dir)
    {
        //_rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _rb.AddForce(dir * _dashPower, ForceMode.Impulse);
    }
}
