using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}

public enum MoveDirection
{
    Left,
    Right,
}
