using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJetPack : MonoBehaviour
{
    public float jetpackforce = 10f;

    public Animator anim;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{

         //  rb.AddForce(new Vector2(0f, jetpackforce), ForceMode2D.Force);

       // }
    }
}
