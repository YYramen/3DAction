using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftCommand : ICommand
{
    readonly TestPlayerController _controller;

    public TurnLeftCommand(TestPlayerController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Turn(MoveDirection.Left);
    }
}
