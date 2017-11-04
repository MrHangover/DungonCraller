using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : Enemy {

	float LookAngle = 0f;
	Vector2 AimDirection = Vector2.zero;

	public override void Start()
	{
		base.Start();

		Move(AimDirection);
	}
		
	public override void Move(Vector2 dir)
	{
		StartCoroutine(Aim());
	}

	IEnumerator Aim()
	{
		AimDirection = FindDirection();

		//transform.rotation = Quaternion.Euler(new Vector3(0f,0f, LookAngle));

		yield return new WaitForSeconds(1f);
	}
		
	IEnumerator Charge()
	{
		yield return new WaitForEndOfFrame();	
	}


	Vector2 FindDirection()
	{
		Vector2 dir = transform.position - player.position;
		LookAngle = Vector2.Angle(transform.position, player.position);
		Debug.DrawRay(transform.position, player.position, Color.red, 10f);
		Debug.Log("PLayer: "+player.position);
		return dir;
	}



	public override void KnockBack(Vector2 direction, float force)
	{
		throw new System.NotImplementedException();
	}

	public override void Damage(float damage)
	{
		throw new System.NotImplementedException();
	}

	protected override void Die()
	{
		throw new System.NotImplementedException();
	}
}
