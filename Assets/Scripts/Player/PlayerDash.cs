using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player�̃_�b�V���@�\�N���X�BInputSystem���g��
/// </summary>
public class PlayerDash : MonoBehaviour
{
    [Header("�_�b�V���@�\")]
    [SerializeField, Tooltip("Ray���΂��ʒu")] Transform _rayPos;
    [SerializeField, Tooltip("�_�b�V������")] float _dashRange = 3.0f;
    [SerializeField] int _rayValue;
    [Header("�Q�Ɨp")]
    [SerializeField] PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnFrontDash;
        _playerInput.onActionTriggered += OnBackDash;
        _playerInput.onActionTriggered += OnRightDash;
        _playerInput.onActionTriggered += OnLeftDash;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnFrontDash;
        _playerInput.onActionTriggered -= OnBackDash;
        _playerInput.onActionTriggered -= OnRightDash;
        _playerInput.onActionTriggered -= OnLeftDash;
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
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.forward, out hitObj, _dashRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _dashRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.forward * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.forward * _dashRange;
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
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.back, out hitObj, _dashRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _dashRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.back * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.back * _dashRange;
            }
            Debug.Log($"BackDash {context.phase}");

        }
    }

    public void OnRightDash(InputAction.CallbackContext context)
    {
        if (context.action.name != "RightDash")
        {
            return;
        }

        if (context.performed)
        {
            RaycastHit hitObj;
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.right, out hitObj, _dashRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _dashRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.right * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.right * _dashRange;
            }
            Debug.Log($"RightDash {context.phase}");
        }
    }

    public void OnLeftDash(InputAction.CallbackContext context)
    {
        if (context.action.name != "LeftDash")
        {
            return;
        }

        if (context.performed)
        {
            RaycastHit hitObj;
            bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.left, out hitObj, _dashRange);

            if (hit && hitObj.collider.gameObject.layer == _rayValue)
            {
                Debug.Log(hitObj.distance);
                if (hitObj.distance < 0.8f)
                {
                    return;
                }
                else
                {
                    float b = _dashRange - hitObj.distance - 0.2f;
                    transform.position = transform.position + Vector3.left * b;
                }
            }
            else
            {
                transform.position = transform.position + Vector3.left * _dashRange;
            }
            Debug.Log($"LeftDash {context.phase}");
        }
    }
}
