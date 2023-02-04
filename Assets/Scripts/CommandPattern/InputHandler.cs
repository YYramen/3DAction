using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Invoker _invoker;
    bool _isReplaying, _isRecording;
    TestPlayerController _playerController;
    ICommand _leftCommand, _rightCommand;

    void Start()
    {
        // 依存解決
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<TestPlayerController>();

        // コマンド作成
        _leftCommand = new TurnLeftCommand(_playerController);
        _rightCommand = new TurnRightCommand(_playerController);
    }

    void Update()
    {
        if (!_isReplaying && _isRecording)
        {
            // Aボタン入力時のコマンドを実行する
            if (Input.GetKeyUp(KeyCode.A))
                _invoker.ExecuteCommand(_leftCommand);

            // Dボタン入力時のコマンドを実行する
            if (Input.GetKeyUp(KeyCode.D))
                _invoker.ExecuteCommand(_rightCommand);
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("StartRecording"))
        {
            _playerController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            // Invoker を通じて記録開始
            _invoker.Record();
        }

        if (GUILayout.Button("StopRecording"))
        {
            _playerController.ResetPosition();
            _isRecording = false;
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Replay"))
            {
                _playerController.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                // Invoker を通じてリプレイ開始
                _invoker.Replay();
            }
        }
    }
}
