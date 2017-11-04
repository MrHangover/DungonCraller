using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour {

    public Transform originPoint;

    public void SetGraphics(GameObject handle, GameObject head){

        handle.transform.SetParent(originPoint);
        head.transform.SetParent(originPoint);
    }
}
