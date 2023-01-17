using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの攻撃アニメーションを制御するクラス
/// </summary>
public class AttackAnimator : StateMachineBehaviour
{
    //public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.ResetTrigger("Attack");
    //    Debug.Log("攻撃1");
    //}

    //public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        animator.SetTrigger("Attack");
    //    }
    //}

    //public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (stateInfo.IsName("Attack"))
    //    {
    //        animator.ResetTrigger("Attack");
    //        Debug.Log("攻撃終了");
    //    }
    //}
}
