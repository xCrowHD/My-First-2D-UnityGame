using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2tpLocal : MonoBehaviour
{
    [HideInInspector]
    public Transform playerPos;
    public Transform newPos;
    // Start is called before the first frame update

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerPos.position = newPos.position;
        }
    }
}
