using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIStateMove : StateMachineBehaviour
{
    EnemyGM enemyGM;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyGM = animator.GetComponent<EnemyGM>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move(enemyGM);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    private void Move(EnemyGM enemyGM)
    {
        enemyGM.enemyAi.PathFollow();
    }
}
