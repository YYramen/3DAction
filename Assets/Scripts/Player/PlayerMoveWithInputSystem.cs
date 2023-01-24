using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveWithInputSystem : MonoBehaviour
{
    public void OnPunch(InputAction.CallbackContext context)
    {
        Debug.Log("パンチ");
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        Debug.Log("キック");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("移動");
    }
}
