using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoomContentItem : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectRef { private get; set; }
    

    void OnDestroy()
    {
        DestroyImmediate (objectRef);
    }
}
