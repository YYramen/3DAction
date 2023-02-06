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
    [SerializeField, Tooltip("ダッシュ力")] float _dashPower;
    [Header("参照用")]
    [SerializeField] PlayerInput _playerInput;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

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
            //RaycastHit hitObj;
            //bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.forward, out hitObj, _dashRange);

            //if (hit && hitObj.collider.gameObject.layer == _rayValue)
            //{
            //    Debug.Log(hitObj.distance);
            //    if (hitObj.distance < 0.8f)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        float b = _dashRange - hitObj.distance - 0.2f;
            //        transform.position = transform.position + Vector3.forward * b;
            //    }
            //}
            //else
            //{
            //    transform.position = transform.position + Vector3.forward * _dashRange;
            //}
            _rb.AddForce(Vector3.right * _dashPower, ForceMode.Impulse);

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
            //RaycastHit hitObj;
            //bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.back, out hitObj, _dashRange);

            //if (hit && hitObj.collider.gameObject.layer == _rayValue)
            //{
            //    Debug.Log(hitObj.distance);
            //    if (hitObj.distance < 0.8f)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        float b = _dashRange - hitObj.distance - 0.2f;
            //        transform.position = transform.position + Vector3.back * b;
            //    }
            //}
            //else
            //{
            //    transform.position = transform.position + Vector3.back * _dashRange;
            //}
            _rb.AddForce(Vector3.left * _dashPower, ForceMode.Impulse);

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
            //RaycastHit hitObj;
            //bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.right, out hitObj, _dashRange);

            //if (hit && hitObj.collider.gameObject.layer == _rayValue)
            //{
            //    Debug.Log(hitObj.distance);
            //    if (hitObj.distance < 0.8f)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        float b = _dashRange - hitObj.distance - 0.2f;
            //        transform.position = transform.position + Vector3.right * b;
            //    }
            //}
            //else
            //{
            //    transform.position = transform.position + Vector3.right * _dashRange;
            //}
            _rb.AddForce(Vector3.back * _dashPower, ForceMode.Impulse);

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
            //RaycastHit hitObj;
            //bool hit = Physics.Raycast(_rayPos.transform.position, Vector3.left, out hitObj, _dashRange);

            //if (hit && hitObj.collider.gameObject.layer == _rayValue)
            //{
            //    Debug.Log(hitObj.distance);
            //    if (hitObj.distance < 0.8f)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        float b = _dashRange - hitObj.distance - 0.2f;
            //        transform.position = transform.position + Vector3.left * b;
            //    }
            //}
            //else
            //{
            //    transform.position = transform.position + Vector3.left * _dashRange;
            //}
            _rb.AddForce(Vector3.forward * _dashPower, ForceMode.Impulse);

            Debug.Log($"LeftDash {context.phase}");
        }
    }
}
