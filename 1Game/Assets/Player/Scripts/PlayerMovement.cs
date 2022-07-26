using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    public PlayerStats stats;

    public bool m_FacingRight = true;
    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {


         movement = Input.GetAxisRaw("Horizontal");

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(stats.rb.velocity.y) < 0.001f)
        {
            
            stats.rb.AddForce(new Vector2(0, stats.jumpforce), ForceMode2D.Impulse);
            stats.animator.SetBool("jump", true);

        }
        stats.animator.SetBool("jump", false);
        

        // If the input is moving the player right and the player is facing left...
        if (Input.GetAxisRaw("Horizontal") > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Input.GetAxisRaw("Horizontal") < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

    }
    private void FixedUpdate()
    {
        
        transform.position += new Vector3(movement, 0, 0) * stats.movespeed * Time.deltaTime;
        stats.animator.SetFloat("speed", Mathf.Abs(movement));

    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180, 0);
    }
}
