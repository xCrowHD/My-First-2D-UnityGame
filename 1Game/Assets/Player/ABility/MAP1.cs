using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MAP1 : MeleeAbilities
{
    public override void Effect(EnemySkills e)
    {
        e.StunEffect();
    }
}
