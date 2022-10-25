using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player‚Ìí“¬ŠÖŒW
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
    /// “ü—Í‚ğó‚¯•t‚¯‚é
    /// </summary>
    private void InputAttack()
    {
        if (Input.GetButtonDown("Fire1") && _attackOne == false)
        {
            _attackOne = true;
            _anim.SetTrigger("Attack1");
            Debug.Log("UŒ‚‚P");
        }
        else if (Input.GetButtonDown("Fire2") && _attackTwo == false)
        {
            _attackTwo = true;
            _anim.SetTrigger("Attack2");
            Debug.Log("UŒ‚‚Q");
        }
        else
        {
            _attackOne = false;
            _attackTwo = false;
        }
    }
}
