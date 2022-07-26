using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealthScript : MonoBehaviour
{
   [Header("PlayerStatsComponent")]
    public PlayerStats stats;
   //[Header("EnemyComponent")]
    //public EnemyHealth enemyhealth;

    [Header("Variables")]
    
    public int currenthealth;
    private bool isonfire = false;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        if((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1")))
        {
            currenthealth = stats.maxhealth;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
      //-------------------BerserkLogic parameters----------------

        if(currenthealth < (int)stats.maxhealth / 4 && stats.ability.berserk == 1)
        {
            stats.render.material.color = Color.red;
            
        }
        if(currenthealth >(int)stats.maxhealth / 4 && stats.ability.berserk == 1)
        {

            stats.render.material.color = Color.white;
        }

    }
    
    public void TakeDMGPlayer(int dmg)
    {
      currenthealth -= dmg;
      stats.healthbar.SetHealth(currenthealth);
      //stats.animator.SetTrigger("hurt");

    }
   
    public void TakeDMGOverTimePlayer(int dmgpersecond1, int totaldmg1, Color newColor, float everyxtime1)
    {


        // fa 5 dammi extra quindi sono 40 in veritá
        if (isonfire == false)
        {

            StartCoroutine(FireBulletsDMGOverTime(dmgpersecond1, totaldmg1, newColor, everyxtime1));
            IEnumerator FireBulletsDMGOverTime(int dmgpersecond, int totaldmg, Color newcolor1, float everyxtime)
            {
                float amountdmged = 0;

                isonfire = true;

                stats.render.material.color = newcolor1;

                while (amountdmged < totaldmg && currenthealth > 0)
                {
                    currenthealth -= dmgpersecond;
                    stats.healthbar.SetHealth(currenthealth);

                    yield return new WaitForSeconds(everyxtime);
                   
                    // stats.animator.SetTrigger("hurt");
                    amountdmged += dmgpersecond;


                }
                isonfire = false;
                stats.render.material.color = Color.white;

            }
        }

    }
}
