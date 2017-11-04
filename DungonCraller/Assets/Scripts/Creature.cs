using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Creature : MonoBehaviour {

    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float friction;
    [SerializeField]
    float health;
    [SerializeField]
    float weight;

    protected abstract void Move(Vector2 direction);
    protected abstract void KnockBack(Vector2 direction, float force);
    protected abstract void Damage(float damage);
}
