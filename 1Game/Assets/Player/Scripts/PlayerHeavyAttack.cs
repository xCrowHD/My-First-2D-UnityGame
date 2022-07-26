using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyAttack : MonoBehaviour
{
    [Header("HeavyAttackVariables")]
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public PlayerStats stats;
    public IDamagable stuneffect;

    public float attackRange = 0.3f;
    
    private void Start()
    {
        stats = GetComponent<PlayerStats>();

    }
    public void HeavyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //------------BerserkAtkON---------------
            if (stats.health.currenthealth <= (int)stats.maxhealth / 4 && stats.ability.berserk == 1)
            {

                enemy.GetComponent<EnemyHealth>().TakeDMGWithKnockBack((int)(stats.meleeDMG + (int)(stats.meleeDMG / 2)*1.3f));

            }
            //---------------BerserkOff----------
            else
            {

                enemy.GetComponent<EnemyHealth>().TakeDMGWithKnockBack((int)(stats.meleeDMG * 1.3f));
            }

            if (stats.ability.mAbility != null)
            {
                if (stats.ability.lifeSteal == 1)
                {
                    stats.ability.mAbility.Effect(this.gameObject);
                }
                if (stats.ability.meleestun == 1)
                {
                    stats.ability.mAbility.Effect(enemy.GetComponent<EnemySkills>());
                }
            }
        }


    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
