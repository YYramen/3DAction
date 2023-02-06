using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchKickComboCommand : ICommand
{
    PlayerCommandController _controller;

    public PunchKickComboCommand(PlayerCommandController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.PunchKickCombo();
    }
}
