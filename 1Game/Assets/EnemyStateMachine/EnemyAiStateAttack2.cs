using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiStateAttack2 : StateMachineBehaviour
{
    EnemyGM enemyGM;

    [Header("Variables")]
    public bool PathON;
    public float attackRange, CloseRange, AtkCD;
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
            Attack2NoPath(attackRange, CloseRange, AttackParameterName, enemyGM);
            
        }
        if (PathON == true && Time.time >= nextAttack)
        {
            Attack2WithPath(attackRange, CloseRange, AttackParameterName, enemyGM);
            
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(AttackParameterName);
    }

    private void Attack2NoPath(float attackRange, float CloseRange, string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position) && TooCloseRange(CloseRange, enemyGM.playerPosition.position, enemyGM.transform.position))
        {
            enemyGM.isAttacking = true;
            enemyGM.animator.SetTrigger(AttackParameterName);
            nextAttack = Time.time + AtkCD;
        }
    }
    private void Attack2WithPath(float attackRange, float CloseRange, string AttackParameterName, EnemyGM enemyGM)
    {
        if (RangeCheck(attackRange, enemyGM.playerPosition.position, enemyGM.transform.position) && TooCloseRange(CloseRange, enemyGM.playerPosition.position, enemyGM.transform.position))
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
    private bool TooCloseRange(float atkRange3, Vector2 PlayerPos, Vector2 EnemyPos)
    {
        bool InRange = false;
        if (Vector2.Distance(PlayerPos, EnemyPos) >= atkRange3)
        {
            return InRange = true;
        }
        else
        {
            return InRange;
        }
    }
}
