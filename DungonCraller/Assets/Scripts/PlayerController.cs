using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creature
{
    protected override void Damage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void KnockBack(Vector2 direction, float force)
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }
}
