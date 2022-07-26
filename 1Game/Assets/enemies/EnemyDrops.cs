using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [HideInInspector]
    public EnemyGM enemyGM;


    private void Start()
    {
        enemyGM = GetComponent<EnemyGM>();
    }
    public void Healthpotdrop()
    {
        var rand = Random.Range(1, 100);
        if (rand >= 1 && rand <= 20)
        {
            enemyGM.stats.pot.healthpotnumber = ++enemyGM.stats.pot.healthpotnumber;
        }
    }

    

    public void DropAmmo()
    {

        var rand = Random.Range(1, 100);
        if (rand >= 21 && rand <= 40)
        {
            enemyGM.stats.bullets.bullets += 10;
        }

    }

    
    public void CoinsDrop(int amount)
    {

        enemyGM.stats.coins.coins += amount;

    }


}
