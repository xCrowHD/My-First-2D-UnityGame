using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletDMGNumber : MonoBehaviour
{
    public TextMeshProUGUI txmeshpro;
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        txmeshpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txmeshpro.text = stats.bulletdmg.ToString();
    }
}
