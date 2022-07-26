using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiStateCloseAttack : StateMachineBehaviour
{

    EnemyGM enemyGM;

    [Header("Variables")]
    public bool PathON;
    public float attackRange, AtkCD;
    public string AttackParameterName;
    private float nextAttack = 0f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyGM = animator.GetComponent<EnemyGM>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PathON == false && Time.time >= nextAttack)
        {
            CloseRangeAttackNoPath(attackRange, AttackParameterName, enemyGM);
            
        }
        if (PathON == true && Time.time >= nextAttack)
        {
            CloseRangeAttackWithPath(attackRange, AttackParameterName, enemyGM);
            
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(AttackParameterName);
    }
    public void CloseRangeAttackNoPath(float attackRange, string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position))
        {
            enemyGM.isAttacking = true;
            enemyGM.animator.SetTrigger(AttackParameterName);
            nextAttack = Time.time + AtkCD;
        }
    }
    public void CloseRangeAttackWithPath(float attackRange,  string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position))
        {
            enemyGM.enemyAi.PathFollow();
            enemyGM.isAttacking = true;
            enemyGM.animator.SetTrigger(AttackParameterName);
            nextAttack = Time.time + AtkCD;
        }
    }
    private bool RangeCheck(float atkRange, Vector2 PlayerPos, Vector2 EnemyPos)
    {
        bool InRange = false;

        if (Vector2.Distance(PlayerPos, EnemyPos) <= atkRange)
        {
            return InRange = true;
        }
        else
        {
            return InRange;
        }

    }
   
}
