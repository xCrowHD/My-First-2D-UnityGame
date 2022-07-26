using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[HideInInspector]
	public EnemyGM enemyGM;
	public int attackDamage = 20;
	

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	private void Start()
	{
		enemyGM = GetComponent<EnemyGM>();
	}
	public void Attack1()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			
			colInfo.GetComponent<PlayerHealthScript>().TakeDMGPlayer(attackDamage);
			
			enemyGM.enemyHealth.ReflectDMG();
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
