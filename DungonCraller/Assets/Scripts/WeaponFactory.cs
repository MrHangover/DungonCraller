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
        System.Type wType = GetWeaponClassFromType(weaponType);
        Weapon w = weapon.AddComponent(wType) as Weapon;
        w.damage = GlobalBaseValues.WEAPON_BASE_VALUES[weaponType];

        return weapon;
    }

    public System.Type GetWeaponClassFromType(Weapon.WeaponType type){
        switch (type)
        {
            case Weapon.WeaponType.Sword:
                return typeof(Sword);
            case Weapon.WeaponType.Hammer:
                return typeof(Sword); // XD
            case Weapon.WeaponType.Flail:
                return typeof(Sword); // XD
            case Weapon.WeaponType.Bow:
                return typeof(Sword); // XD
            case Weapon.WeaponType.Dagger:
                return typeof(Sword); // XD
            case Weapon.WeaponType.Fist:
                return typeof(Sword); // XD
            default:
                return typeof(Sword); // XD
        }
    }

}
