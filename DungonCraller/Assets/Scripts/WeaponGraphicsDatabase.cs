using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class WeaponGraphicsDatabase : ScriptableObject
{

    public Gradient colorVariations;

    public List<WeaponGraphicsAssets> WeaponGraphics;


    //Wow nice copy pasta code
    public GameObject GetRandomHandle(Weapon.WeaponType type)
    {
        WeaponGraphicsAssets assetGroup = WeaponGraphics.FirstOrDefault(x => x.Type == type);
        int idx = Random.Range(0, assetGroup.Handles.Count);

        GameObject handle = Instantiate(assetGroup.Handles[idx]);
        foreach (SpriteRenderer r in handle.GetComponentsInChildren<SpriteRenderer>())
        {
            r.material.color = colorVariations.Evaluate(Random.Range(0f, 1f));
        }

        return handle;
    }

    public GameObject GetRandomHead(Weapon.WeaponType type)
    {
        WeaponGraphicsAssets assetGroup = WeaponGraphics.FirstOrDefault(x => x.Type == type);
        int idx = Random.Range(0, assetGroup.Heads.Count);

        GameObject head = Instantiate(assetGroup.Heads[idx]);
        foreach (SpriteRenderer r in head.GetComponentsInChildren<SpriteRenderer>())
        {
            r.material.color = colorVariations.Evaluate(Random.Range(0f, 1f));
        }

        return head;
    }
}

[System.Serializable]
public class WeaponGraphicsAssets
{
    public Weapon.WeaponType Type;
    public List<GameObject> Handles = new List<GameObject>();
    public List<GameObject> Heads = new List<GameObject>();
}