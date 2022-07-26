using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDmgOverTime : MonoBehaviour
{
	[HideInInspector]
	public EnemyGM enemyGM;
	public int attackDamage = 5;
	public int maxDmg;
	public Color color;
	public float tickRate;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	private void Start()
	{
		enemyGM = GetComponent<EnemyGM>();
	}
	public void AttackDOT()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{

			colInfo.GetComponent<PlayerHealthScript>().TakeDMGOverTimePlayer(attackDamage, maxDmg, color, tickRate);
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
