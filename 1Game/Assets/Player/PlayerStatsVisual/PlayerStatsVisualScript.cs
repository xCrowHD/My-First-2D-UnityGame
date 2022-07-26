using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsVisualScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerstats;
    bool playerstatsImage = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && playerstatsImage == false)
        {

            playerstats.SetActive(true);
            playerstatsImage = true;


        }
        else if(Input.GetKeyDown(KeyCode.J) && playerstatsImage == true)
        {

            playerstats.SetActive(false);
            playerstatsImage = false;

        }
    }
}
