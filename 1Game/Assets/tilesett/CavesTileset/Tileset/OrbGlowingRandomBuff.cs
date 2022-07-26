using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGlowingRandomBuff : MonoBehaviour
{
    PlayerStats stats;
    private bool alreadyUsed = false;
    private void Update()
    {
        if(stats == null)
        {
            stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (alreadyUsed == false)
            {
                var randNumber = Random.Range(1, 99);
                if (randNumber >= 1 && randNumber <= 50)
                {

                    stats.meleeDMG += 5;
                    stats.bulletdmg += 5;
                    alreadyUsed = true;
                }
                if (randNumber >= 50 && randNumber < 99)
                {
                    stats.maxhealth += 30;
                    stats.maxstamina += 30;
                    alreadyUsed = true;

                }
            }
        }
    }
}
