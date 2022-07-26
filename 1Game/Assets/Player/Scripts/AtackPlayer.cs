using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
    [SerializeField]
    private float attackRate;
    public float basicAttackRate = 0.5f;
    public float heavyAttackRate = 2f;

    [Header("BasicAttackVariables")]
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public PlayerStats stats;
    
    

    public float attackRange = 0.3f;
    private float nextAttackTime = 0f;
    private float temnpsavemovespeed;

    
    // Start is called before the first frame update

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Time.time >= nextAttackTime)
        {
            CheckForHeavyAttackStrings();
            ChangeAttackCD();

            if (Input.GetKeyDown(KeyCode.Z))

            {
                
                stats.animator.SetTrigger(stats.attackString);
                nextAttackTime = Time.time + attackRate;


            }

        }
        
    }
    public void FreezeWhileHeavyAttack()
    {
        temnpsavemovespeed = stats.movespeed;
        stats.movespeed = 0f;

    }
    public void UNFreezeWhileHeavyAttack()
    {
        stats.movespeed = temnpsavemovespeed;
    }
    private void ChangeAttackCD()
    {
        if (stats.ability.heavyAttack == 1)
        {
            attackRate = heavyAttackRate;
        }
        else
        {

            attackRate = basicAttackRate;
        }

    }
    private void CheckForHeavyAttackStrings()
    {
        if(stats.ability.heavyAttack == 1)
        {
            stats.attackString = "HeavyAttack";
        }
        else
        {
            stats.attackString = "atk";

        }


    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //------------BerserkAtkON---------------
            if (stats.health.currenthealth <= (int)stats.maxhealth / 4  && stats.ability.berserk == 1)
            {

                enemy.GetComponent<EnemyHealth>().TakeDMG(stats.meleeDMG + (int)(stats.meleeDMG/2));

            }
            //---------------BerserkOff----------
            else
            {

                enemy.GetComponent<EnemyHealth>().TakeDMG(stats.meleeDMG);
            }
            
            if(stats.ability.mAbility != null)
            {
                if(stats.ability.lifeSteal == 1)
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
