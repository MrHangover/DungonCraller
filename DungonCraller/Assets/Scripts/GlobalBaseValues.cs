using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalBaseValues
{

    public static Dictionary<Weapon.WeaponType, float> WEAPON_BASE_VALUES = new Dictionary<Weapon.WeaponType, float>(){
        {Weapon.WeaponType.Sword, 5f},
        {Weapon.WeaponType.Dagger, 2f},
        {Weapon.WeaponType.Flail, 10f}
    }
}
