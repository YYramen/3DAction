using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンドのインターフェース
/// </summary>
public interface ICommand
{
    void Execute();
}

public enum MoveDirection
{
    DownBack = 1,
    Down = 2,
    DownFront = 3,
    Back = 4,
    Neutral = 5,
    Front = 6,
    UpBack = 7,
    Up = 8,
    UpFront = 9,
}
