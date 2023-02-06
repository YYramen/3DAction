using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestCommandPattern;

namespace TestCommandPattern
{
    public class TestInputHandler : MonoBehaviour
    {
        TestInvoker _invoker;
        bool _isReplaying, _isRecording;
        TestPlayerController _playerController;
        TestICommand _leftCommand, _rightCommand;

        void Start()
        {
            // �ˑ�����
            _invoker = gameObject.AddComponent<TestInvoker>();
            _playerController = FindObjectOfType<TestPlayerController>();

            // �R�}���h�쐬
            _leftCommand = new TestTurnLeftCommand(_playerController);
            _rightCommand = new TestTurnRightCommand(_playerController);
        }

        void Update()
        {
            if (!_isReplaying && _isRecording)
            {
                // A�{�^�����͎��̃R�}���h�����s����
                if (Input.GetKeyUp(KeyCode.A))
                    _invoker.ExecuteCommand(_leftCommand);

                // D�{�^�����͎��̃R�}���h�����s����
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
                // Invoker ��ʂ��ċL�^�J�n
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
                    // Invoker ��ʂ��ă��v���C�J�n
                    _invoker.Replay();
                }
            }
        }
    }
}

