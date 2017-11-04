using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class WeaponGraphicsDatabase : ScriptableObject {

    public List<WeaponGraphicsAssets> WeaponGraphics;

    //Wow nice copy pasta code
    public GameObject GetRandomHandle(Weapon.WeaponType type){ 
        WeaponGraphicsAssets assetGroup = WeaponGraphics.FirstOrDefault(x => x.Type == type);
        int idx = Random.Range(0, assetGroup.Handles.Count);
        return assetGroup.Handles[idx];
    }

    public GameObject GetRandomHead(Weapon.WeaponType type){
        WeaponGraphicsAssets assetGroup = WeaponGraphics.FirstOrDefault(x => x.Type == type);
        int idx = Random.Range(0, assetGroup.Heads.Count);
        return assetGroup.Heads[idx];
    }
}

[System.Serializable]
public class WeaponGraphicsAssets{
    public Weapon.WeaponType Type;
    public List<GameObject> Handles = new List<GameObject>();
    public List<GameObject> Heads = new List<GameObject>();
}