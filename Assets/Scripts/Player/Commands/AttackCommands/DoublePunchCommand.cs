using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �p���`�ƃL�b�N���������̃R�}���h
/// </summary>
public class DoublePunchCommand : ICommand
{
    PlayerCommandController _controller;

    public DoublePunchCommand(PlayerCommandController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.DoublePunch();
    }
}
