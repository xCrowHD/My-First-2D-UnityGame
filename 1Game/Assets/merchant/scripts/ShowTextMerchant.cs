using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextMerchant : MonoBehaviour
{

    
    public Transform player;
    public Rigidbody2D rb;
    public GameObject B;
   
    public GameObject merchantShop;
    public float distance = 3f;
    private bool shopmenuImage = false;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        ShowBText();
        ShowShop();
    }

    public void ShowBText()
    {


        if (Vector2.Distance(player.position, rb.position) < distance)
        {

            B.SetActive(true);

        }
        else if (Vector2.Distance(player.position, rb.position) > distance)
        {

            B.SetActive(false);

        }

    }

    public void ShowShop()
    {

        if(Input.GetKeyDown(KeyCode.B) && shopmenuImage == false && Vector2.Distance(player.position, rb.position) < distance)
        {

            merchantShop.SetActive(true);
            shopmenuImage = true;

        }
        else if (Input.GetKeyDown(KeyCode.B) && shopmenuImage == true )
        {

            merchantShop.SetActive(false);
            shopmenuImage = false;

        }

    }

}
