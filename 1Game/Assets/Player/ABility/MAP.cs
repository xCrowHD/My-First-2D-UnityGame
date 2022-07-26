using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MAP : MeleeAbilities
{
    public override void Effect(GameObject o)
    {
        PlayerStats stats = o.GetComponent<PlayerStats>();
        stats.health.currenthealth = stats.health.currenthealth + (int)(stats.meleeDMG / 3);
        stats.healthbar.SetHealth(stats.health.currenthealth);
        if (stats.health.currenthealth > stats.maxhealth)
        {

            stats.health.currenthealth = stats.maxhealth;

        }
    }
}
