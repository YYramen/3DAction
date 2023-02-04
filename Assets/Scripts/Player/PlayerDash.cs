using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Playerのダッシュ機能クラス。InputSystemを使う
/// </summary>
public class PlayerDash : MonoBehaviour
{
    [Header("ダッシュ機能")]
    [SerializeField, Tooltip("Rayを飛ばす位置")] Transform _rayPos;
    [SerializeField, Tooltip("ダッシュ距離")] float _rayRange = 3.0f;
    [SerializeField] int _rayValue;
    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnFrontDash;
        _playerInput.onActionTriggered += OnBackDash;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnFrontDash;
        _playerInput.onActionTriggered -= OnBackDash;
    }

    public void OnFrontDash(InputAction.CallbackContext context)
    {
        if (context.action.name != "FrontDash")
        {
            return;
        }

        if (context.performed)
        {
            RaycastHit hitObj;
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.forward, out hitObj, _rayRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _rayRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.forward * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.forward * _rayRange;
            }
            Debug.Log($"FrontDash {context.phase}");

        }
    }

    public void OnBackDash(InputAction.CallbackContext context)
    {
        if (context.action.name != "BackDash")
        {
            return;
        }

        if (context.performed)
        {
            RaycastHit hitObj;
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.back, out hitObj, _rayRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _rayRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.back * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.back * _rayRange;
            }
            Debug.Log($"BackDash {context.phase}");

        }
    }
}
