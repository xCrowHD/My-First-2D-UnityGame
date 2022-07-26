using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]
    public EnemyGM enemyGM;
    //public Sprite hurtImage;
    //public Sprite idle;
   // public GameObject floatdmg;

    public int currenthealth;
    public int maxhealth = 100;
    public int coinsdropamount = 20;
    private Vector2 knockbackHeavy = new  Vector2(30f, 0f);
    private Vector2 knockbackReflect = new Vector2(10f, 0f);
    private bool dropped = false;
    public bool isonfire = false;
    [Header("AnimatorStringNames")]
    public string deadString;
    public string hurtString;

    // Start is called before the first frame update
    void Start()
    {
        //------------GM component------
        enemyGM = GetComponent<EnemyGM>();
        if (enemyGM.isWeak == true)
        {

            maxhealth = maxhealth * 75/100;

        }
        if (enemyGM.isStrong == true)
        {

            maxhealth = maxhealth + (maxhealth / 2);

        }
        if (enemyGM.isABoss == true)
        {

            maxhealth = maxhealth * 3;

        }
        
        
        //-----------sets health-----------
        currenthealth = maxhealth;
    }

    void Update()
    {
       
        if (currenthealth <= 0 && enemyGM.isAlive == true)
        {
            Die();
        }
    }


  
   
    //-----------------------HealthLogic-------------------
    public void TakeDMG(int dmg)
    {

        currenthealth = currenthealth - dmg;
        if (enemyGM.isAttacking == false)
        {
            enemyGM.animator.SetTrigger(hurtString);
         
        }
        
    }

    public void TakeDMGWithKnockBack(int dmg)
    {
        if (enemyGM.isHealing == false)
        {
            currenthealth = currenthealth - dmg;
        }
        
        if (enemyGM.isAttacking == false || enemyGM.isHealing == false)
        {
            enemyGM.animator.SetTrigger(hurtString);

        }
        if (enemyGM.flip.isFlipped)
        {
            enemyGM.rb.AddForce((knockbackHeavy), ForceMode2D.Impulse);
        }
        if (!enemyGM.flip.isFlipped)
        {
            enemyGM.rb.AddForce(-(knockbackHeavy), ForceMode2D.Impulse);
        }

    }

    public void TakeDMGOverTime(int dmgpersecond1, int totaldmg1,Color newColor, float everyxtime1)
    {

        if (isonfire == false || enemyGM.isHealing == false)
        {

            StartCoroutine(FireBulletsDMGOverTime(dmgpersecond1, totaldmg1, newColor, everyxtime1));
            IEnumerator FireBulletsDMGOverTime(int dmgpersecond, int totaldmg, Color newcolor1, float everyxtime)
            {
                float amountdmged = 0;

                isonfire = true;

                enemyGM.render.material.color = newcolor1;

                while (amountdmged < totaldmg && currenthealth > 0)
                {

                    yield return new WaitForSeconds(everyxtime);

                    currenthealth -= dmgpersecond;
                    enemyGM.animator.SetTrigger(hurtString);
                    amountdmged += dmgpersecond;
                    
                }
                isonfire = false;
                enemyGM.render.material.color = Color.white;

            }
        }

    }
    public void ReflectDMG()
    {
        var rand = Random.Range(1, 100);
        if (enemyGM.stats.ability.reflectdmg == 1 && rand >= 1 && rand < 50 && enemyGM.isHealing == false)
        {
            enemyGM.rb.AddForce((knockbackReflect),ForceMode2D.Impulse);
            currenthealth -= enemyGM.stats.meleeDMG;
            enemyGM.animator.SetTrigger(hurtString);
        }
        
    }
    
    public void Die()
    {
        if(dropped == false)
        {
            enemyGM.drops.Healthpotdrop();
            enemyGM.drops.CoinsDrop(coinsdropamount);
            enemyGM.drops.DropAmmo();
            dropped = true;
        }
        enemyGM.animator.SetTrigger(deadString);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<Collider2D>().enabled = false;
        
    }
    
   
}
