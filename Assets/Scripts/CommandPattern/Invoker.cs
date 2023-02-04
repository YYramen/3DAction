using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    bool _isRecording, _isReplaying;
    float _replayTime, _recordingTime;
    readonly SortedList<float, ICommand> _recordedCommands = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();

        if (_isRecording)
        {
            _recordedCommands.Add(_recordingTime, command);
        }
    }

    /// <summary>
    /// �R�}���h�̋L�^���s��
    /// </summary>
    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    /// <summary>
    /// �R�}���h�̍Ď��s���s��
    /// </summary>
    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;

        if (_recordedCommands.Count <= 0)
            Debug.LogError("���v���C�\�ȃR�}���h������܂���.");
    }

    void FixedUpdate()
    {
        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;

        if (_isReplaying)
        {
            _replayTime += Time.fixedDeltaTime;

            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}
