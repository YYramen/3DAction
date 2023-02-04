using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCommand : ICommand
{
    readonly TestPlayerController _controller;

    public TurnRightCommand(TestPlayerController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Turn(MoveDirection.Right);
    }
}
