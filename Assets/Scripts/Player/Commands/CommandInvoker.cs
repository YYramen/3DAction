using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンド発行クラス。コマンドの記録も行う
/// </summary>
public class CommandInvoker : MonoBehaviour
{
    readonly List<ICommand> _recordCommandList = new List<ICommand>();

    public void ExecuteCommand(ICommand commands)
    {
        commands.Execute();

        _recordCommandList.Add(commands);
    }
}
