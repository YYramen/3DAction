using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// コマンドの入力を受け付けるクラス
/// </summary>
public class InputCommandHandler : MonoBehaviour
{
    //[Header("参照用")]
    //[SerializeField, Tooltip("PlayerInput")] PlayerInput _input;

    CommandInvoker _invoker;
    PlayerCommandController _controller;

    ICommand _punchKickCombo,
             _kickPunchCombo,
             _doublePunch;

    private void Start()
    {
        _invoker = gameObject.AddComponent<CommandInvoker>();
        _controller = FindObjectOfType<PlayerCommandController>();

        _punchKickCombo = new PunchKickComboCommand(_controller);
        _kickPunchCombo = new KickPunchComboCommand(_controller);
        _doublePunch = new DoublePunchCommand(_controller);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _invoker.ExecuteCommand(_punchKickCombo);
        }
        else if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            _invoker.ExecuteCommand(_kickPunchCombo);
        }
        else if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            _invoker.ExecuteCommand(_doublePunch);
        }
    }
}
