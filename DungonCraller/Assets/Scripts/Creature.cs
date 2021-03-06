﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Creature : MonoBehaviour {

    [SerializeField]
    protected float acceleration;
    [SerializeField]
    protected float maxSpeed;
    [SerializeField]
    protected float friction;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float weight;
    [SerializeField]
    protected float strength;

    public abstract void Move(Vector2 direction);
    public abstract void KnockBack(Vector2 direction, float force);
    public abstract void Damage(float damage);
    protected abstract void Die();
}
