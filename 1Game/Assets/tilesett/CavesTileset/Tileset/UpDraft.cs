using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDraft : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    
    public float upDraftForce;
    // Update is called once per frame
    void Update()
    {
        
        if (rbPlayer == null)
        {
            rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            UpdraftPlayer();
        }
        

    }
    private void UpdraftPlayer()
    {

        rbPlayer.AddForce((new Vector2(0f, upDraftForce)), ForceMode2D.Impulse);
        

    }
    
}
