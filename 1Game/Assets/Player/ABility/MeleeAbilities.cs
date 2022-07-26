using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbilities : ScriptableObject
{
    public virtual void Effect(GameObject o) { }
    public virtual void Effect(EnemySkills e) { }
}
