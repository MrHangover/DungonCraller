using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour {

    public Transform originPoint;

    public void SetGraphics(GameObject handle, GameObject head){

        handle.transform.SetParent(originPoint);
        handle.transform.localPosition = Vector3.zero;

        head.transform.SetParent(originPoint);
        head.transform.localPosition = Vector3.zero;
    }
}
