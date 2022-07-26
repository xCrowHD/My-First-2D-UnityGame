using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Playerbulletcount : MonoBehaviour
{
    public TextMeshProUGUI txmeshpro;
    public int bullets = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetSceneByName("Level1").isLoaded)
        {


            bullets = PlayerPrefs.GetInt("bulletsstart", 10);

        }
        else
        {
            bullets = PlayerPrefs.GetInt("bullets");
        }
        
        txmeshpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerPrefs.SetInt("bullets", bullets);
    }
}
