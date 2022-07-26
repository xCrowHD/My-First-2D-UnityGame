using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPref;
    
    public void Shoot()
    {

        Instantiate(bulletPref, firepoint.position, firepoint.rotation);

    }
}
