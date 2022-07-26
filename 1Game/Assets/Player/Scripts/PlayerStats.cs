using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{   [Header("PlayerStats")]
    public int maxhealth = 100;
    public int maxstamina = 100;
    public int meleeDMG = 30;
    public int bulletdmg = 20;
    public int healingamount = 30;
    public float movespeed = 4.5f;
    public float jumpforce = 15;
    public int maxBullets = 10;

    [Header("PlayerComponents")]
    //----------PlayerScripts-----------
    public PlayerAbilties ability;
    public Playerbulletcount bullets;
    public PlayerCoins coins;
    public PlayerHealthScript health;
    public PlayerMovement move;
    public PlayerShooting shoot;
    public PlayerStaminaBar stamina;
    public PlayerTP tp;
    public HealthBarPlayer healthbar;
    public Renderer render;
    public Animator animator;
    public Rigidbody2D rb;
    public HealthPot pot;
    [Header("AttackNameVariables")]
    public string attackString;
    [Header("Lists of abilities")]
    public List<Bullet> bulletsList = new List<Bullet>();
    public List<MeleeAbilities> mAbility = new List<MeleeAbilities>();

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetSceneByName("Level1").isLoaded)
        {
            //----------------Getting the saves of ability-----------------
            ability.lifeSteal = PlayerPrefs.GetInt("lifeSteal_Start", 0 );
            ability.firebullets = PlayerPrefs.GetInt("firebullets_Start", 0);
            ability.toxicbullets = PlayerPrefs.GetInt("toxicbullets_Start", 0);
            ability.lightningbullets = PlayerPrefs.GetInt("lightningbullets_Start", 0);
            ability.berserk = PlayerPrefs.GetInt("berserk_Start", 0);
            ability.stealth = PlayerPrefs.GetInt("stealth_Start", 0);
            ability.meleestun = PlayerPrefs.GetInt("meleestun_Start", 0);
            ability.reflectdmg = PlayerPrefs.GetInt("reflectdmg_Start", 0);
            ability.heavyAttack = PlayerPrefs.GetInt("heavyAttack_Start", 0);
            //---------------Getting the saves of stats-----------
            maxhealth = PlayerPrefs.GetInt("maxhealth_Start", 100);
            health.currenthealth = PlayerPrefs.GetInt("currenthealth_Start", maxhealth);
            healthbar.slider.maxValue = PlayerPrefs.GetFloat("healthbar.slider.maxValue_Start", maxhealth);
            healthbar.slider.value = PlayerPrefs.GetFloat("healthbar.slider.value_Start", maxhealth);
            maxstamina = PlayerPrefs.GetInt("maxstamina_Start", 100);
            stamina.slider.maxValue = PlayerPrefs.GetFloat("stamina.slider.maxValue_Start", maxstamina);
            meleeDMG = PlayerPrefs.GetInt("meleeDMG_Start", 30);
            bulletdmg = PlayerPrefs.GetInt("bulletdmg_Start", 20);
            healingamount = PlayerPrefs.GetInt("healingamount_Start", 30);
            movespeed = PlayerPrefs.GetFloat("movespeed_Start", 4.5f);
            jumpforce = PlayerPrefs.GetFloat("jumpforce_Start", 15);
            pot.healthpotnumber = PlayerPrefs.GetInt("pot_Start", 3);
            maxBullets = PlayerPrefs.GetInt("maxBullets_Start", 10);
        }
        else
        {
            //----------------Getting the saves of ability-----------------
            ability.lifeSteal = PlayerPrefs.GetInt("lifeSteal");
            ability.firebullets = PlayerPrefs.GetInt("firebullets");
            ability.toxicbullets = PlayerPrefs.GetInt("toxicbullets");
            ability.lightningbullets = PlayerPrefs.GetInt("lightningbullets");
            ability.berserk = PlayerPrefs.GetInt("berserk");
            ability.stealth = PlayerPrefs.GetInt("stealth");
            ability.meleestun = PlayerPrefs.GetInt("meleestun");
            ability.reflectdmg = PlayerPrefs.GetInt("reflectdmg");
            ability.heavyAttack = PlayerPrefs.GetInt("heavyAttack");

            // getting the ability obj

            if(ability.firebullets == 1)
            {
                ability.bullet = bulletsList[0];
            }
            if (ability.toxicbullets == 1)
            {
                ability.bullet = bulletsList[1];
            }
            if (ability.lightningbullets == 1)
            {
                ability.bullet = bulletsList[2];
            }
            if(ability.meleestun == 1){
                ability.mAbility = mAbility[0];
            }
            if(ability.lifeSteal == 1){
                ability.mAbility = mAbility[1];
            }

            //---------------Getting the saves of stats-----------
            maxhealth = PlayerPrefs.GetInt("maxhealth");
            health.currenthealth = PlayerPrefs.GetInt("currenthealth");
            healthbar.slider.maxValue = PlayerPrefs.GetFloat("healthbar.slider.maxValue");
            healthbar.slider.value = PlayerPrefs.GetFloat("healthbar.slider.value");
            maxstamina = PlayerPrefs.GetInt("maxstamina");
            stamina.slider.maxValue = PlayerPrefs.GetFloat("stamina.slider.maxValue");
            meleeDMG = PlayerPrefs.GetInt("meleeDMG");
            bulletdmg = PlayerPrefs.GetInt("bulletdmg");
            healingamount = PlayerPrefs.GetInt("healingamount");
            movespeed = PlayerPrefs.GetFloat("movespeed");
            jumpforce = PlayerPrefs.GetFloat("jumpforce");
            pot.healthpotnumber = PlayerPrefs.GetInt("pot");
            maxBullets = PlayerPrefs.GetInt("maxBullets");
        }
        
    }

    // Update is called once per frame
    void Update()
    {   
        //-------------setting stats----------
        PlayerPrefs.SetInt("maxhealth", maxhealth);
        PlayerPrefs.SetInt("currenthealth", health.currenthealth);
        PlayerPrefs.SetFloat("healthbar.slider.maxValue", healthbar.slider.maxValue);
        PlayerPrefs.SetFloat("healthbar.slider.value", healthbar.slider.value);
        PlayerPrefs.SetInt("maxstamina", maxstamina);
        PlayerPrefs.SetFloat("stamina.slider.maxValue", stamina.slider.maxValue);
        PlayerPrefs.SetInt("meleeDMG", meleeDMG);
        PlayerPrefs.SetInt("bulletdmg", bulletdmg);
        PlayerPrefs.SetInt("healingamount", healingamount);
        PlayerPrefs.SetFloat("movespeed", movespeed);
        PlayerPrefs.SetFloat("jumpforce", jumpforce);
        PlayerPrefs.SetInt("pot", pot.healthpotnumber);
        PlayerPrefs.SetInt("maxBullets", maxBullets);

        //-------------settings ability--------
        PlayerPrefs.SetInt("lifeSteal", ability.lifeSteal);
        PlayerPrefs.SetInt("firebullets", ability.firebullets);
        PlayerPrefs.SetInt("toxicbullets", ability.toxicbullets);
        PlayerPrefs.SetInt("lightningbullets", ability.lightningbullets);
        PlayerPrefs.SetInt("berserk", ability.berserk);
        PlayerPrefs.SetInt("stealth", ability.stealth);
        PlayerPrefs.SetInt("meleestun", ability.meleestun);
        PlayerPrefs.SetInt("reflectdmg", ability.reflectdmg);
        PlayerPrefs.SetInt("heavyAttack", ability.heavyAttack);
    }
}
