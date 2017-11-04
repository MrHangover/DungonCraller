using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour {

    public Transform originPoint;

    public void SetGraphics(GameObject handle, GameObject head){

        Instantiate(handle, originPoint.position, Quaternion.identity, originPoint);
        Instantiate(head, originPoint.position, Quaternion.identity, originPoint);
    }
}
