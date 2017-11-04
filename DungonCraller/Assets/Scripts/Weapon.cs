using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public abstract class Weapon : MonoBehaviour {

    float durabilityPrHitScale;
    float damageScale;
    float weightScale;
    float dragScale;

    float durabilityPrHit;
    float durability;
    float damage;
    float weight;
    float weaponDragSpeed;

    SliderJoint2D slider;

    protected virtual void Start()
    {
        slider = GetComponent<SliderJoint2D>();
    }

    protected abstract void Aim(Vector2 mousePos);
    protected abstract void Activate();
}
