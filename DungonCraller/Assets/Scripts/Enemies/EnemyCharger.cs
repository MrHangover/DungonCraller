using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : Enemy {

	float LookAngle = 0f;
	Vector2 AimDirection = Vector2.zero;
	Vector2 AimPoint = Vector2.zero;
	public float ChargeSpeed = 5f;
	bool hasHit = false;

	public override void Start()
	{
		hasHit = false;
		base.Start();
		StartCoroutine(Attack());
	}

	public void Update()
	{
		Move(AimDirection);
	}

	public override void Move(Vector2 dir)
	{
		if(Vector3.Angle((player.position - hand.transform.position), hand.transform.up) > 100){
			Friction();	
		}
	}

	IEnumerator Attack()
	{
		while(true){
			// LOOK
			hasHit = false;
			AimDirection = FindDirection();
			float LookAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
			hand.transform.rotation = Quaternion.Euler(0f, 0f, LookAngle - 90);
			AimPoint = dir;
			yield return new WaitForSeconds(1f);

			// Charge
			rb.AddForce(AimDirection.normalized*ChargeSpeed, ForceMode2D.Impulse);
			yield return new WaitForSeconds(2f);
		}
	}

	public void SetHasHit(){
		hasHit = true;
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
	}
		
	Vector2 FindDirection()
	{
		Vector2 dir = player.position-hand.transform.position ;
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
