﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadAttack : MonoBehaviour
{
	public int attackDamage = 10;


	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack1()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealthScript>().TakeDMGPlayer(attackDamage);
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
