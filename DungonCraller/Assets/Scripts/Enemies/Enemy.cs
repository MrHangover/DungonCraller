using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature {

    protected Transform player;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public GameObject hand;
	public Vector2 dir;

    // Use this for initialization
    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        player = GameManager.Instance.player;
    }

	public virtual void Accelerate(Vector2 direction)
	{
		if (direction.sqrMagnitude == 0f)
		{
			return;
		}

		Vector2 addedAcceleration = direction.normalized * acceleration * Time.deltaTime;
		if ((rb.velocity + addedAcceleration).magnitude > maxSpeed)
		{
			addedAcceleration = rb.velocity - (rb.velocity + addedAcceleration).normalized * maxSpeed;
		}
		rb.velocity += addedAcceleration;
	}

	public virtual void Friction()
	{
		Vector2 normalizedVelocity = rb.velocity.normalized;
		Vector2 appliedFriction = -normalizedVelocity * friction * Time.deltaTime;
		rb.velocity += appliedFriction;
		if (rb.velocity.normalized != normalizedVelocity)
		{
			rb.velocity = Vector2.zero;
		}
	}

    public virtual void Attack()
    {

    }
    

}
