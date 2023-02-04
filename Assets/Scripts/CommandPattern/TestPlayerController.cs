using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    float _distance = 1.0f;

    public void Turn(MoveDirection direction)
    {
        if (direction == MoveDirection.Left)
        {
            transform.Translate(Vector3.left * _distance);
            Debug.Log("ç∂Ç…ì¸óÕ");
        }

        if (direction == MoveDirection.Right)
        {
            transform.Translate(Vector3.right * _distance);
            Debug.Log("âEÇ…ì¸óÕ");
        }
    }

    public void ResetPosition()
    {
        this.transform.position = Vector3.zero;
    }
}
