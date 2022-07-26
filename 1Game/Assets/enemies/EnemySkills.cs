using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkills : MonoBehaviour
{
    [HideInInspector]
    public EnemyGM enemyGM;
    
    public int healingAmount = 50;
    public float stealthseconds = 5;
    public bool stealthUsed = false;
    public Transform positionEnemyHasToTP;
    // Start is called before the first frame update
    void Start()
    {
        enemyGM = GetComponent<EnemyGM>();
    }

    public void EnemyHealing()
    {

        enemyGM.enemyHealth.currenthealth += healingAmount;

    }
    public void EnemyTP()
    {

        transform.position = positionEnemyHasToTP.position;


    }
    public void StealthVoid()
    {
        StartCoroutine(Stealth());
        IEnumerator Stealth()
        {


            enemyGM.stats.render.material.color = new Color(1f, 1f, 1f, 0.5f);
            enemyGM.animator.SetBool(enemyGM.stealthParameters, true);
            enemyGM.animator.Play(enemyGM.idleAnimation);
            yield return new WaitForSeconds(stealthseconds);
            enemyGM.animator.SetBool(enemyGM.stealthParameters, false);
            enemyGM.stats.render.material.color = new Color(1f, 1f, 1f, 1f);
            stealthUsed = true;

        }

    }
    public virtual void StunEffect()
    {
        StartCoroutine(Stuneffect1());
        IEnumerator Stuneffect1()
        {

            enemyGM.animator.Play(enemyGM.idleAnimation);
            enemyGM.animator.SetBool(enemyGM.stunnedParameters, true);
            enemyGM.render.material.color = Color.yellow;
            yield return new WaitForSeconds(2f);
            enemyGM.animator.SetBool(enemyGM.stunnedParameters, false);
            enemyGM.render.material.color = Color.white;


        }

    }
}
