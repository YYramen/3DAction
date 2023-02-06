using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestCommandPattern;

namespace TestCommandPattern
{
    public class TestPlayerController : MonoBehaviour
    {
        float _distance = 1.0f;

        public void Turn(MoveDirection direction)
        {
            if (direction == MoveDirection.Left)
            {
                transform.Translate(Vector3.left * _distance);
                Debug.Log("���ɓ���");
            }

            if (direction == MoveDirection.Right)
            {
                transform.Translate(Vector3.right * _distance);
                Debug.Log("�E�ɓ���");
            }
        }

        public void ResetPosition()
        {
            this.transform.position = Vector3.zero;
        }
    }
}