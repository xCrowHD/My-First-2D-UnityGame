using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBullet : Bullet
{
    public override void Effect(EnemyHealth e)
    {
        e.TakeDMGOverTime(dmgXsec, totalDmg, color, tickRate);
    }
}
