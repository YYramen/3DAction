using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// InputSystem���g�p����Player�̈ړ��R���|�[�l���g
/// </summary>
public class PlayerMoveWithInputSystem : MonoBehaviour
{
    [Header("�ړ����x")]
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed;
    [Tooltip("�ړ��͂��i�[�p���Ă����ϐ�")] Vector3 _movement;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * _moveSpeed;
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Debug.Log("�p���`");
        }
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("�L�b�N");
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        _movement = new Vector3(movementVector.x, 0.0f, movementVector.y);
    }
}
