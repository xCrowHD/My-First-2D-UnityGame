using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ScriptableObject
{
    public new string name;
    public int dmgXsec, totalDmg;
    public Color color;
    public float tickRate;


    public virtual void Effect(EnemyHealth e)
    {

    }
}
