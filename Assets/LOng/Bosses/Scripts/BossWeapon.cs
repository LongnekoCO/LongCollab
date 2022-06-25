using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;
	public PlayerMovementScript player;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	public bool attackHit;
	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		if (attackHit == true)

		{
			player.TakeDamage(attackDamage);
		}
		
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			
			//colInfo.GetComponent<PlayerMovementScript>().TakeDamage(attackDamage);
			
		}
	}
	
	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		if (attackHit == true)
		{
			player.TakeDamage(enragedAttackDamage);
		}
		//player.TakeDamage(attackDamage);
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			player.TakeDamage(enragedAttackDamage);
			//colInfo.GetComponent<PlayerMovementScript>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			attackHit = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			attackHit = false;
		}
	}
}
