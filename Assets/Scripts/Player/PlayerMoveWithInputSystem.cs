using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの移動クラス。InputSystemを使用している
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveWithInputSystem : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] float _playerSpeed;

    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    Animator _anim;
    Rigidbody _rb;
    Vector3 _movement;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnMove;
    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move")
            return;
        Vector2 inputMove = context.ReadValue<Vector2>();
        _movement = new Vector3(inputMove.y * -1, 0, inputMove.x);
    }

    void Update()
    {
        _rb.velocity = _movement * _playerSpeed * 10;

        _anim.SetFloat("Front", _rb.velocity.z);
        _anim.SetFloat("Side", _rb.velocity.x);
    }
}