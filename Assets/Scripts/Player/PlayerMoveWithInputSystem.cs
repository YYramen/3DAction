using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// InputSystemを使用したPlayerの移動コンポーネント
/// </summary>
public class PlayerMoveWithInputSystem : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField, Tooltip("移動速度")] float _moveSpeed;
    [Tooltip("移動力を格納用しておく変数")] Vector3 _movement;

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
            Debug.Log("パンチ");
        }
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("キック");
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        _movement = new Vector3(movementVector.x, 0.0f, movementVector.y);
    }
}
