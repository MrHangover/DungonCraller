using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeponLol : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WeaponFactory.Instance.GetWeapon(Weapon.WeaponType.Sword);
	}
}
