using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGM : MonoBehaviour
{
    
    [Header("Variables")]
    public float movespeed = 5.5f;
   
    public string idleAnimation;

    public bool isAttacking = false;
    public bool isHealing = false;
    public bool isAlive = true;
    [Header("EnemySkillsAndStatus")]
    
    
    public bool isWeak = false;
    public bool isStrong = false;
    public bool isABoss = false;
    [Header("AnimatorParameters")]
    public string stealthParameters;
    public string stunnedParameters;
    [HideInInspector]
    public float moveSpeedSaved;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Renderer render;
    [HideInInspector]
    public EnemyDrops drops;
    [HideInInspector]
    public EnemyHealth enemyHealth;
    [HideInInspector]
    public EnemyFlip flip;
    [HideInInspector]
    public EnemyAi enemyAi;
    [HideInInspector]
    public Seeker seeker;
    [HideInInspector]
    public EnemySkills enemySkills;
    [HideInInspector]
    public PlayerStats stats;
    [HideInInspector]
    public Transform playerPosition;

    private float temnpsavemovespeed;
    // Start is called before the first frame update
    void Start()
    {
        
        moveSpeedSaved = movespeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<Renderer>();
        seeker = GetComponent<Seeker>();
        drops = GetComponent<EnemyDrops>();
        enemyHealth = GetComponent<EnemyHealth>();
        flip = GetComponent<EnemyFlip>();
        enemyAi = GetComponent<EnemyAi>();
        enemySkills = GetComponent<EnemySkills>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(stats == null)
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>() != null)
            {
                stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
                playerPosition = stats.transform;
            }
            
        }

    }
    
    public void SetIsAttackingFalse()
    {

        isAttacking = false;

    }
    public void SetFalseAfterDeath()
    {

        gameObject.SetActive(false);

    }
    public void SetEnemyAiOff()
    {

        enemyAi.enabled = false;
        seeker.enabled = false;
        
    }
    public void SettingBoxColliderOFF()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 0f;
    }
    public void SettingBoxColliderON()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        rb.gravityScale = 5f;
    }
    public void Freeze()
    {
        temnpsavemovespeed = movespeed;
        movespeed = 0f;
        
    }
    public void UnFreeze()
    {
        movespeed = temnpsavemovespeed;
       
    }
    public void KnockBack()
    {
       if(this.transform.position.x > playerPosition.position.x)
        {
            stats.rb.AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);
        }
       else
        {
            stats.rb.AddForce(new Vector2(10f, 0), ForceMode2D.Impulse);
        }
    }
    public void IsDead()
    {

        isAlive = false;
    }
    
    public void Healing()
    {

        isHealing = true;
    }
    public void StopHealing()
    {

        isHealing = false;
    }
}
