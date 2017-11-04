using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour {

    public enum WeaponType
    {
        Sword,
        Hammer,
        Flail,
        Bow,
        Dagger,
        Fist
    };

    public Vector2 velocity;
    public WeaponType type;
    public float durabilityPrHitScale;
    public float damageScale;
    public float weightScale;
    public float dragScale;

    public float maxSpeed;
    public float durabilityPrHit;
    public float durability;
    public float damage;
    public float weight;
    public float weaponDragSpeed;

	public UnityEvent OnSendDamage;

    protected abstract void Activate();
}
