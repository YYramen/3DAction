using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestCommandPattern;

namespace TestCommandPattern
{
    public class TestTurnRightCommand : TestICommand
    {
        readonly TestPlayerController _controller;

        public TestTurnRightCommand(TestPlayerController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            _controller.Turn(MoveDirection.Right);
        }
    }
}
