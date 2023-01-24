using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveWithInputSystem : MonoBehaviour
{
    public void OnPunch(InputAction.CallbackContext context)
    {
        Debug.Log("�p���`");
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        Debug.Log("�L�b�N");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("�ړ�");
    }
}
