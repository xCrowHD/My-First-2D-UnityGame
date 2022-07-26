using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWheelBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 20f;
    public int bulletdmg = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthScript player = collision.GetComponent<PlayerHealthScript>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDMGPlayer(bulletdmg);

        }
        Destroy(gameObject);
    }
}
