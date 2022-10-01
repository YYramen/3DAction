using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField,Tooltip("�ړ����x")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _aimPos;
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
    /// ���͂��󂯕t����֐�
    /// </summary>
    private void InputMove()
    {
        // ���͂��󂯕t����
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
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
    }
}
