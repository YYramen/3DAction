using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestCommandPattern;

namespace TestCommandPattern
{
    public interface TestICommand
    {
        void Execute();
    }

    public enum MoveDirection
    {
        Left,
        Right,
    }
}

