using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyWeapon : Weapon {

	protected override void Activate(){}
	public float ImpactForce = 1f;
    public bool destroyOnImpact = false;

	public void OnCollisionEnter2D(Collision2D col){
        print(col.gameObject);
		Creature C = col.gameObject.GetComponent<Creature>();
		if(C != null){
			C.Damage(damage);
			C.KnockBack(C.transform.position-this.transform.position, ImpactForce);
			OnSendDamage.Invoke();

            print("HIT " + col.gameObject+" "+gameObject.name);

            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
		}
	}
}
