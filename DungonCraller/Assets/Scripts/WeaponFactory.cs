using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : Singleton<WeaponFactory>
{
    public WeaponGraphicsDatabase WeaponDatabase;
    public GameObject WeaponTemplate;

    public GameObject GetWeapon(Weapon.WeaponType weaponType){
        GameObject weapon = Instantiate(WeaponTemplate) as GameObject;
        
        //Construct weapon
        GameObject blade = WeaponDatabase.GetRandomHead(weaponType);
        GameObject handle = WeaponDatabase.GetRandomHandle(weaponType);

        //Graphics
		WeaponGraphics wg = weapon.GetComponent<WeaponGraphics>();
        wg.SetGraphics(handle, blade);

        //TODO: Actual weapon stats here...

        return weapon;
    }

}
