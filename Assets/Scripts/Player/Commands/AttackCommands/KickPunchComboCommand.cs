using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPunchComboCommand : ICommand
{
    PlayerCommandController _controller;

    public KickPunchComboCommand(PlayerCommandController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.KickPunchCombo();
    }
}
