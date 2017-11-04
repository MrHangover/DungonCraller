using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    BoxCollider2D boxCollider;
    Rigidbody2D body;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    public override void Damage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }

    protected override void Die()
    {
        //TODO do more than just remove the gameObject.
        Destroy(gameObject);
    }

    public override void KnockBack(Vector2 direction, float force)
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector2 direction)
    {
        Friction();

        Accelerate(direction);
    }

    void Accelerate(Vector2 direction)
    {
        if(direction.sqrMagnitude == 0f)
        {
            return;
        }

        Vector2 addedAcceleration = direction.normalized * acceleration * Time.deltaTime;
        if ((body.velocity + addedAcceleration).magnitude > maxSpeed)
        {
            addedAcceleration = body.velocity - (body.velocity + addedAcceleration).normalized * maxSpeed;
        }
        body.velocity += addedAcceleration;
    }

    void Friction()
    {
        Vector2 normalizedVelocity = body.velocity.normalized;
        Vector2 appliedFriction = -normalizedVelocity * friction * Time.deltaTime;
        body.velocity += appliedFriction;
        if(body.velocity.normalized != normalizedVelocity)
        {
            body.velocity = Vector2.zero;
        }
    }

    void Attack()
    {

    }
}
