using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestCommandPattern;

namespace TestCommandPattern
{
    public class TestTurnLeftCommand : TestICommand
    {
        readonly TestPlayerController _controller;

        public TestTurnLeftCommand(TestPlayerController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            _controller.Turn(MoveDirection.Left);
        }
    }
}
