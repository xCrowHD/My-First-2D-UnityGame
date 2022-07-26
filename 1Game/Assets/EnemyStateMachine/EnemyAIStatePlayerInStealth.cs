using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIStatePlayerInStealth : StateMachineBehaviour 
{
    EnemyGM enemyGM;
    
    private float timeinstealth = 0f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    enemyGM = animator.GetComponent<EnemyGM>();
}
public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
        PlayerInStealth(enemyGM, timeinstealth);
}
public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    
}
    public void PlayerInStealth(EnemyGM enemyGM, float timeinstealth)
    {
        if (enemyGM.enemySkills.stealthUsed == false && enemyGM.stats.health.currenthealth <= enemyGM.stats.maxhealth / 2 && enemyGM.stats.ability.stealth == 1 && Time.time > timeinstealth)
        {
            timeinstealth = Time.time + enemyGM.enemySkills.stealthseconds + 0.01f;
            enemyGM.enemySkills.StealthVoid();
            enemyGM.enemySkills.stealthUsed = true;
        }
    }
}
