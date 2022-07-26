using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;

   
    // Start is called before the first frame update
    void Start()
    {
        
        
        Instantiate(player, new Vector3(this.transform.position.x, this.transform.position.y, 0),Quaternion.identity);
    }

    
}
