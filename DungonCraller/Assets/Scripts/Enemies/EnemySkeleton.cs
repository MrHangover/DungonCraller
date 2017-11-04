using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy {

    Vector2 destination;
    Vector2 direction;
    public float attackrange;
    public float waitTime = 2f;
    

	// Use this for initialization
	public override void Start ()
    {
   //     AAEMusicLooper.OnBeat += Attack;
        
        base.Start();
        FindDirection();
        StartCoroutine("MoveOverTime");
        Attack();
    }
	
	// Update is called once per frame
	public void Update ()
    {
        Move(direction);
    }

    public override void Attack()
    {
        hand.transform.Rotate(new Vector3(0,0,-90f));
        StartCoroutine("AttackWait");
    }


    
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(2f);
        Attack();
    }



    Vector2 FindDirection()
    {
        print("find");
        destination = player.position;
        if (Vector2.Distance(transform.position, destination) > attackrange)
        {
            direction = (player.position - transform.position).normalized;
        }
        return destination;
    }
    
    
    IEnumerator MoveOverTime()
    {
        
        print("moveovertime");
        while (Vector2.Distance(transform.position,destination) > attackrange)
        {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("WaitMovement");
    }

    IEnumerator WaitMovement()
    {
//        rb.velocity = Vector2.zero;
        direction = Vector2.zero;
        print("wait");
        StopCoroutine("MoveOverTime");
        yield return new WaitForSeconds(2);
        FindDirection();
        StartCoroutine("MoveOverTime");
    }


    public override void Move(Vector2 direction)
    {
       // print("DISTANCE: "+Vector2.Distance(transform.position, destination) + " POS: " + transform.position + " DEST: " + destination+" DIR: "+direction);

        if (direction.sqrMagnitude == 0f)
        {
            Friction();
        }

        Accelerate(direction);
    }

    void Accelerate(Vector2 direction)
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

    void Friction()
    {
        Vector2 normalizedVelocity = rb.velocity.normalized;
        Vector2 appliedFriction = -normalizedVelocity * friction * Time.deltaTime;
        rb.velocity += appliedFriction;
        if (rb.velocity.normalized != normalizedVelocity)
        {
            rb.velocity = Vector2.zero;
        }
    }
    


    public override void KnockBack(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    public override void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {

        //drop some loot and shieet. 
        //particles!

        Destroy(gameObject);
    }
}
