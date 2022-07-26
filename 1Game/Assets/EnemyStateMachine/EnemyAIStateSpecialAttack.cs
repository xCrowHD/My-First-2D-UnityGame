using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIStateSpecialAttack : StateMachineBehaviour
{
    EnemyGM enemyGM;
    [Header("Variables")]
    public bool PathON;
    public float attackRange;
    public string AttackParameterName = null;
    public bool SpecialAttackUsed = false;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyGM = animator.GetComponent<EnemyGM>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PathON == false && SpecialAttackUsed == false)
        {
            SpecialAttackNoPath(attackRange, AttackParameterName, enemyGM);
            
        }
        if (PathON == true && SpecialAttackUsed == false)
        {
            SpecialAttackWithPath(attackRange, AttackParameterName, enemyGM);
            
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(AttackParameterName);
    }
    public void SpecialAttackWithPath(float attackRange, string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position) && enemyGM.enemyHealth.currenthealth <= (int)(enemyGM.enemyHealth.maxhealth / 2) )
        {
            enemyGM.enemyAi.PathFollow();
            enemyGM.isAttacking = true;
            enemyGM.animator.SetTrigger(AttackParameterName);
            SpecialAttackUsed = true;
        }
    }
    public void SpecialAttackNoPath(float attackRange, string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position) && enemyGM.enemyHealth.currenthealth <= (int)(enemyGM.enemyHealth.maxhealth / 2) )
        {
            enemyGM.isAttacking = true;
            enemyGM.animator.SetTrigger(AttackParameterName);
            SpecialAttackUsed = true;
        }

    }
    public bool RangeCheck(float atkRange, Vector2 PlayerPos, Vector2 EnemyPos)
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
