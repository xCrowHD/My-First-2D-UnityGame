using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPref;
    
   
    public PlayerStats stats;
    private float WeaponReady =  0;
    private float firerate = 1.5f;
    private float reloadRate = 2f;
    public bool isReloading = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Time.time >= WeaponReady && stats.bullets.bullets > 0)
        {

            Shoot();
            stats.animator.SetTrigger("LightBlast");
            WeaponReady = Time.time + 1/firerate;
            stats.bullets.bullets--;
           
        }
        
        if(stats.bullets.bullets == 0 )
        {
            isReloading = true;
            StartCoroutine(ReloadingCD());
            
        }

        if(stats.bullets.bullets > stats.maxBullets)
        {
            stats.bullets.bullets = stats.maxBullets;
        }


        if (isReloading)
        {
            stats.bullets.txmeshpro.text = "Reloding...";
        }
        else { stats.bullets.txmeshpro.text = stats.bullets.bullets.ToString(); }
    }
    
     void Shoot()
    {

        Instantiate(bulletPref, firepoint.position, firepoint.rotation);
        
    }

    public IEnumerator ReloadingCD()
    {
        yield return new WaitForSeconds(reloadRate);
        isReloading = false;
        stats.bullets.bullets = stats.maxBullets;
    }
}
