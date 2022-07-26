using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElettricFieldDmg : MonoBehaviour
{
    PlayerStats stats;


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

            stats.health.TakeDMGOverTimePlayer(3, 15, Color.red, 2f);

        }
    }

}
