using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBlastBehaviour : MonoBehaviour
{
    public int blastDmg = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthScript player = collision.GetComponent<PlayerHealthScript>();
        if (player != null)
        {

            player.TakeDMGPlayer(blastDmg);

        }

        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject, 0.75f);
    }
}
