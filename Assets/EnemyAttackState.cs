﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyFSM
{
    float dir;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dir = animator.gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x;
        MonoBehaviour.print(dir);
        if (dir < 0)
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        GameEvent.current.takeHit(animator.gameObject);
       // animator.GetComponent<Rigidbody2D>().AddForce(new Vector2("x axis", "y axis"))
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
