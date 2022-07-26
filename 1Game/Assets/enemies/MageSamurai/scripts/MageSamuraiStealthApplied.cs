using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSamuraiStealthApplied : MonoBehaviour
{
    public float stealthseconds = 5;
    public bool stealthUsed = false;

    public Animator anim;
   
    public PlayerStats stats;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }
    public void StealthApplied()
    {
        StartCoroutine(Stealth());
        IEnumerator Stealth()
        {


            stats.render.material.color = new Color(1f, 1f, 1f, 0.5f);
            anim.SetBool("stealth", true);
            anim.Play("MageSamuraiIdle");
            yield return new WaitForSeconds(stealthseconds);
            anim.SetBool("stealth", false);
            stats.render.material.color = new Color(1f, 1f, 1f, 1f);
            stealthUsed = true;


        }



    }
}
