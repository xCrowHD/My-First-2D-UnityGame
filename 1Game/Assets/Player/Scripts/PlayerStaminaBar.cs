using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStaminaBar : MonoBehaviour
{
    public Slider slider;
    public PlayerStats stats;
    private WaitForSeconds regentick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    

    
    public int currentstam;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        currentstam = stats.maxstamina;
        slider.maxValue = stats.maxstamina;
        slider.value = currentstam;
        
    }

   

    public void UseStam(int amount)
    {
        
            currentstam -=  amount;
            slider.value = currentstam;

        if (regen != null)
        {
            StopCoroutine(regen);

        }
            regen = StartCoroutine(RegenStam());
    }
    
    private IEnumerator RegenStam()
    {
        yield return new WaitForSeconds(2);

        while(currentstam < stats.maxstamina)
        {

            currentstam += stats.maxstamina / 100;
            slider.value = currentstam;
            yield return regentick;
        }
        regen = null;
    }
}
