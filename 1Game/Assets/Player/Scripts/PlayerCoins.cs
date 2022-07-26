using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerCoins : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txmeshpro;
    public int coins = 0;
    void Start()
    {
        if (SceneManager.GetSceneByName("Level1").isLoaded)
        {

            coins = PlayerPrefs.GetInt("coinsstart" , 0);
        }
        else
        {

            coins = PlayerPrefs.GetInt("coins");

        }
        
        txmeshpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        txmeshpro.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }
}
