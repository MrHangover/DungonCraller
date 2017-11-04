using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeponLol : MonoBehaviour {

    public KeyCode GetNewWeaponKeyCode = KeyCode.I;

    private GameObject instantiatedWeapon;

    void Update(){
        if(Input.GetKeyDown(GetNewWeaponKeyCode)){
            if(instantiatedWeapon != null){
                Destroy(instantiatedWeapon);
            }
            instantiatedWeapon = WeaponFactory.Instance.GetWeapon(Weapon.WeaponType.Sword);
        }
    }
}
