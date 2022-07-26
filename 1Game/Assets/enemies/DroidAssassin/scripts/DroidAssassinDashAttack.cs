using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidAssassinDashAttack : MonoBehaviour
{
    public LayerMask attackMask;
    public float attackRange = 1f;
    public Vector3 attackOffset;
    public int attackDamage = 20;
    EnemyFlip flip;
    public float distance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        flip = GetComponent<EnemyFlip>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    


    public void dashattack()
    {
        Vector3 posmelee = transform.position;
        posmelee += transform.right * attackOffset.x;
        posmelee += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(posmelee, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealthScript>().TakeDMGPlayer(attackDamage);
        }
    }
    public void positionfordashattack()
    {
        if (flip.isFlipped)
        {
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
        }

        else
        {
            transform.position = new Vector2(transform.position.x + distance, transform.position.y);
        }


    }
    
    void OnDrawGizmosSelected()
    {
        Vector3 posmelee = transform.position;
        posmelee += transform.right * attackOffset.x;
        posmelee += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(posmelee, attackRange);
    }
}
