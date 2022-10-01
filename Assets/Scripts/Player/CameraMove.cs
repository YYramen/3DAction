using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの動きを制御するコンポーネント
/// </summary>
public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("カメラの位置")] Transform _camera;

    [SerializeField, Tooltip("カメラのX軸の角度の限界(＋)")] float _xMaxRotation = 70f;
    [SerializeField, Tooltip("カメラのX軸の角度の限界(ー)")] float _xMinRotation = -30f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// 受け取った入力からカメラの向きを変える関数
    /// </summary>
    private void Move()
    {
        // 入力の受け付け
        var inputY = Input.GetAxis("Mouse Y") * -1;

        if (inputY > _xMinRotation && inputY < _xMaxRotation)
        {
            _camera.transform.Rotate(inputY, 0, 0);
        }
    }
}
