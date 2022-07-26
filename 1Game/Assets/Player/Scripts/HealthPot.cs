using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPot : MonoBehaviour
{

    public int healthpotnumber = 3;
    


    public PlayerStats stats;
    
    public Sprite healthpot3;
    public Sprite healthpot2;
    public Sprite healthpot1;
    public Sprite healthpot0;
    public Image healthpotsource;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {//pot check


        if (healthpotnumber > 0 && stats.health.currenthealth < stats.maxhealth)
        {

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //healing
                stats.health.currenthealth = stats.health.currenthealth + stats.healingamount;

                //check se l'healing va oltre il 100
                if (stats.health.currenthealth > stats.maxhealth)
                {

                    stats.health.currenthealth = stats.maxhealth;

                }

                healthpotnumber--;
                //healing display

                stats.healthbar.Healthbarhealing(stats.healingamount, stats.healthbar.slider.value);
            }

        }
        //check se abbiamo piu di 3 pot
        if (healthpotnumber > 3)
        {

            healthpotnumber = 3;

        }

        //image selctor if we have x health pot
        switch (healthpotnumber)
                {
                    case 3:

                        healthpotsource.sprite = healthpot3;

                        return;
                    case 2:

                        healthpotsource.sprite = healthpot2;

                        return;
                    case 1:

                        healthpotsource.sprite = healthpot1;

                        return;
                    case 0:

                        healthpotsource.sprite = healthpot0;

                        return;

                    default:
                        return;
                }

            

            
        
    }
}
