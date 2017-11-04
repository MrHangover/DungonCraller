using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyWeapon : Weapon {

	protected override void Activate(){}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			OnSendDamage.Invoke();
		}
	}
}
