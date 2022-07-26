using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBoxerWalk : StateMachineBehaviour
{
    public float speed = 5f;
    public float attackrange = 3f;
    float timeinstealth;



    Transform player;
    Rigidbody2D rb;
    EnemyFlip flip;
    PlayerAbilties ability;
    SpiritBoxerStealthApplied stealth;
    PlayerStats stats;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // player =  GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flip = animator.GetComponent<EnemyFlip>();
        stealth = animator.GetComponent<SpiritBoxerStealthApplied>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        if (ability == null)
        {

            ability = GameObject.FindWithTag("Player").GetComponent<PlayerAbilties>();

        }
        if (stats == null)
        {

            stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();

        }
        flip.LookAtPlayer();
        //qua muovo lo stronzo
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);



        //attacca
        if (Vector2.Distance(player.position, rb.position) < attackrange)
        {

            
            animator.SetTrigger("atk");
            

        }

        //-------------PlayerStealthAbility--------------
        if (stealth.stealthUsed == false && stats.health.currenthealth <= ability.stats.maxhealth / 2 && ability.stealth == 1 && Time.time > timeinstealth)
        {
            animator.ResetTrigger("atk");
            timeinstealth = Time.time + stealth.stealthseconds + 0.01f;
            stealth.StealthApplied();
            stealth.stealthUsed = true;
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("atk");
    }


}
