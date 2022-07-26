using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilties : MonoBehaviour
{
    
    public PlayerStats stats;
    public Bullet bullet;
    public MeleeAbilities mAbility;

    //------------abilities--------------
    public int lifeSteal = 0;
    public int firebullets = 0;
    public int toxicbullets = 0;
    public int lightningbullets = 0;
    public int berserk = 0;
    public int stealth = 0;
    public int meleestun = 0;
    public int reflectdmg = 0;
    public int heavyAttack = 0;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
       
    }

    private void Update()
    {
        
    }

}
