using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSamuraiBuildUp : MonoBehaviour
{
    public Transform tppos;
    private Transform MageSamuraiTransform;
    public EnemyHealth enemyhealth;
    public Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        MageSamuraiTransform = this.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyhealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TpAway()
    {
        
        MageSamuraiTransform.position = tppos.position;
        
    }

    public void Healing()
    {

        enemyhealth.currenthealth = enemyhealth.maxhealth;

    }
}
