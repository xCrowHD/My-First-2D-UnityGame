﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostWelderIdle : StateMachineBehaviour
{

    public float detectionrange = 8f;

    Transform player;
    public Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // player = GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        if (Vector2.Distance(player.position, rb.position) < detectionrange)
        {

            animator.SetBool("PlayerInRange", true);

        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
