using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoomContentSpawnType : MonoBehaviour
{
    protected List<BaseRoomContentItem> _items = new List<BaseRoomContentItem>();
    public abstract void Spawn ();

    public void DeleteAll ()
    {
        for(int i = _items.Count-1; i >= 0; i--)
        {
            DestroyImmediate (_items[i]);
        }

        _items.Clear ();
    }
}
