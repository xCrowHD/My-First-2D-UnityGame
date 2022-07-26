using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiStateHealing : StateMachineBehaviour
{
    EnemyGM enemyGM;
    [Header("Variables")]
    public bool HealingUsed = false;
    public string HealingParameterName = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyGM = animator.GetComponent<EnemyGM>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (HealingUsed == false && enemyGM.enemyHealth.currenthealth <= (int)(enemyGM.enemyHealth.maxhealth / 2))
        {
            Healing(enemyGM, HealingParameterName);
            HealingUsed = true;
        }
        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(HealingParameterName);
    }
    virtual public void Healing(EnemyGM enemyGM, string HealingParameterName)
    {
        enemyGM.animator.SetTrigger(HealingParameterName);
        enemyGM.enemySkills.EnemyHealing();
    }
}
