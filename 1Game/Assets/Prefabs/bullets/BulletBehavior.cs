using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Bullet bullet;
    public PlayerStats stats;
    public Rigidbody2D rb;
    public float speed = 20f;
    public int firemaxdmg = 40;
    public int toxicmaxdmg = 60;
    public int lightningmaxdmg = 10;
    public float tickrateFire = 1.5f;
    public float tickrateToxic = 3f;
    public float tickrateLightning = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilties>().bullet;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      EnemyHealth  enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            //-----------if is in berserk----------------
            if (stats.health.currenthealth <= (int)stats.maxhealth / 4 && stats.ability.berserk == 1)
            {
                //no effects on bullets
                
                 enemy.TakeDMG(stats.bulletdmg + (int)(stats.bulletdmg / 2));

                // special bullets
                if (bullet != null)
                {
                    if (stats.ability.firebullets == 1 || stats.ability.toxicbullets == 1 || stats.ability.lightningbullets == 1)
                    {

                        bullet.Effect(enemy);

                    }
                }
                
                
            }
            //---------------if is not--------------
            else
            {
                // no effects on bullets
                
                 enemy.TakeDMG(stats.bulletdmg);

                if (bullet != null)
                {
                    if (stats.ability.firebullets == 1 || stats.ability.toxicbullets == 1 || stats.ability.lightningbullets == 1)
                    {

                        bullet.Effect(enemy);

                    }
                }

            }


        }
        
     Destroy(gameObject);
        
    }
    
}
