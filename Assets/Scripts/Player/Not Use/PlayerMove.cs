using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed = 1.0f;

    [Header("���_�ړ�")]
    [SerializeField, Tooltip("�J�����̈ʒu")] Transform _aimPos;
    [SerializeField] AxisState _vertical;
    [SerializeField] AxisState _horizontal;

    Rigidbody _rb;
    Animator _anim;
    int _hashFront = Animator.StringToHash("Front");
    int _hashSide = Animator.StringToHash("Side");

    bool _dashFlg;
    [Header("�_�b�V���@�\")]
    [SerializeField, Tooltip("Ray���΂��ʒu")] Transform _rayPos;
    [SerializeField, Tooltip("�_�b�V������")] float _rayRange = 3.0f;
    [SerializeField] int _rayValue;

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
        Debug.DrawRay(_rayPos.transform.position, transform.forward * _rayRange, Color.blue);
        if (Input.GetButtonDown("Dash"))
        {
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;
            Dash(dir.normalized);
        }

        if (_dashFlg)
        {
            _rb.velocity = Vector3.zero;
            _dashFlg = false;
        }
    }

    /// <summary>
    /// �_�b�V��
    /// </summary>
    /// <param name="dir">�_�b�V���̕���</param>
    private void Dash(Vector3 dir)
    {
        _dashFlg = true;

        RaycastHit hitObj;
        bool hit = Physics.Raycast(_rayPos.transform.position, dir, out hitObj, _rayRange);

        if (hit && hitObj.collider.gameObject.layer == _rayValue)
        {
            Debug.Log(hitObj.distance);
            if (hitObj.distance < 0.8f)
            {
                return;
            }
            else
            {
                float b = _rayRange - hitObj.distance - 0.2f;
                transform.position = transform.position + dir * b;
            }
        }
        else
        {
            transform.position = transform.position + dir * _rayRange;
        }
    }
}
