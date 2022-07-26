using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBoxerStealthApplied : MonoBehaviour
{
    public float stealthseconds = 5;
    public bool stealthUsed = false;

    public Animator anim;
    public PlayerAbilties ability;
    public PlayerStats stats;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (ability == null)
        {

            ability = GameObject.FindWithTag("Player").GetComponent<PlayerAbilties>();

        }
    }
    public void StealthApplied()
    {
        StartCoroutine(Stealth());
        IEnumerator Stealth()
        {


            stats.render.material.color = new Color(1f, 1f, 1f, 0.5f);
            anim.SetBool("stealth", true);
            anim.Play("SpiritBoxerRun");
            yield return new WaitForSeconds(stealthseconds);
            anim.SetBool("stealth", false);
            stats.render.material.color = new Color(1f, 1f, 1f, 1f);
            stealthUsed = true;


        }



    }
}
