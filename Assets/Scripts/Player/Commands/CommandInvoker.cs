using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �R�}���h���s�N���X�B�R�}���h�̋L�^���s��
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
