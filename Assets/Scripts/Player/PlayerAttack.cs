using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̐퓬�֌W
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    bool _attackOne;
    bool _attackTwo;

    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        InputAttack();
    }

    /// <summary>
    /// ���͂��󂯕t����
    /// </summary>
    private void InputAttack()
    {
        if (Input.GetButtonDown("Fire1") && _attackOne == false)
        {
            _attackOne = true;
            _anim.SetTrigger("Attack1");
            Debug.Log("�U���P");
        }
        else if (Input.GetButtonDown("Fire2") && _attackTwo == false)
        {
            _attackTwo = true;
            _anim.SetTrigger("Attack2");
            Debug.Log("�U���Q");
        }
        else
        {
            _attackOne = false;
            _attackTwo = false;
        }
    }
}
