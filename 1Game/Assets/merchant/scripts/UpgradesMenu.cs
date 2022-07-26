using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesMenu : MonoBehaviour
{
    public PlayerStats stats;
    public List<Bullet> bulletList = new List<Bullet>();

    private void Start()
    {
       
    }
    private void Update()
    {
        if (stats == null)
        {
            stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        }
    }


    public void RegenPOTandHealth(int coinscost)
    {
        
        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.health.currenthealth = stats.maxhealth;
            stats.pot.healthpotnumber = 3;
            stats.healthbar.SetHealth(stats.maxhealth);

            Destroy(GameObject.Find("RegenShop"));

        }
        
    }


    public void AddHealth(int coinscost )
    {
        int increase = 30;
        
        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.maxhealth = stats.maxhealth + increase;
            stats.healthbar.SetMaxHealthForShop(stats.maxhealth);
            
            Destroy(GameObject.Find("AddHealthShop"));

        }
        


    }

    public void AddStamina(int coinscost)
    {
        int increase = 30;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.maxstamina += increase;
            stats.stamina.slider.maxValue = stats.maxstamina;

            Destroy(GameObject.Find("AddStaminaShop"));

        }


    }
    public void SpeedBoost(int coinscost)
    {
        int increase = 1;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.movespeed += increase;
            

            Destroy(GameObject.Find("SpeedBoostShop"));

        }


    }

    public void Add5Ammo(int coinscost)
    {
        int increase = 5;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.maxBullets += increase;

            Destroy(GameObject.Find("+5AmmoShop"));

        }


    }


    public void LifeSteal(int coinscost)
    {
        
        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.lifeSteal = 1;
            stats.ability.meleestun = 0;
            Destroy(GameObject.Find("LifeStealShop"));

        }


    }


    public void FireBullets(int coinscost)
    {

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.firebullets = 1;
            stats.ability.toxicbullets = 0;
            stats.ability.lightningbullets = 0;
            stats.ability.bullet = bulletList[0];
            Destroy(GameObject.Find("FireBulletsShop"));

        }


    }

    public void ToxicBullets(int coinscost)
    {

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.toxicbullets = 1;
            stats.ability.firebullets = 0;
            stats.ability.lightningbullets = 0;
            stats.ability.bullet = bulletList[1];
            Destroy(GameObject.Find("ToxicBulletsShop"));

        }


    }
    public void LightningBullets(int coinscost)
    {

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.toxicbullets = 0;
            stats.ability.firebullets = 0;
            stats.ability.lightningbullets = 1;
            stats.ability.bullet = bulletList[2];
            Destroy(GameObject.Find("LightningBulletsShop"));

        }


    }

    public void Berserk(int coinscost)
    {

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.berserk = 1;
            stats.ability.stealth = 0;
            Destroy(GameObject.Find("BerserkShop"));

        }


    }

    public void Add5MeleeDmg(int coinscost)
    {
        int increase = 5;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.meleeDMG += increase;

            Destroy(GameObject.Find("+5MeleeDMGShop"));

        }


    }
    public void Add5BulletDmg(int coinscost)
    {
        int increase = 5;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.bulletdmg += increase;

            Destroy(GameObject.Find("+5BulletDMGShop"));

        }


    }
    public void Add5JumpForce(int coinscost)
    {
        int increase = 5;

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.jumpforce += increase;

            Destroy(GameObject.Find("+5JumpForceShop"));

        }


    }
    public void Stealth(int coinscost)
    {

        if (stats.coins.coins >= coinscost)
        {

            stats.coins.coins -= coinscost;
            stats.ability.berserk = 0;
            stats.ability.stealth = 1;
            Destroy(GameObject.Find("StealthShop"));

        }

    }

    public void MeleeStun(int coinscost)
    {
        if (stats.coins.coins >= coinscost)
        {
            stats.coins.coins -= coinscost;
            stats.ability.lifeSteal = 0;
            stats.ability.meleestun = 1;
            Destroy(GameObject.Find("MeleeStunShop"));
        }
        

    }

    public void ReflectDMG(int coinscost)
    {
        if(stats.coins.coins >= coinscost)
        {
            stats.coins.coins -= coinscost;
            stats.ability.reflectdmg = 1;
            Destroy(GameObject.Find("ReflectDMGShop"));
        }
        

    }
    public void HeavyAttack(int coinscost)
    {
        if (stats.coins.coins >= coinscost)
        {
            stats.coins.coins -= coinscost;
            stats.ability.heavyAttack = 1;
            Destroy(GameObject.Find("HeavyAttackShop"));
        }
        
    }
}
