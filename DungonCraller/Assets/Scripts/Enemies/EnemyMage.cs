using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy {

    Vector2 destination;
    Vector2 direction;

    public float waitToAttack = 1;
    public float waitToMove = 1;
    public float shootSpeed = 5f;

    public GameObject projectile;
    public GameObject deathParticles;


    // Use this for initialization
    public override void Start () {
        base.Start();
        Attack();
	}

    void Update()
    {
        Move(direction);
    }
    

    public override void Attack()
    {
        //shoot
        Vector3 shootDir = (player.position - transform.position);
        GameObject g = Instantiate(projectile, transform.position + shootDir.normalized * 2f, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().velocity = shootDir.normalized * shootSpeed;

        StartCoroutine("WaitToMove");
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(waitToMove);
        FindDirection();
    }
    
    public void FindDirection()
    {
        rb.velocity = Vector3.zero;

        Vector3 playerDir = (player.transform.position - transform.position);
        destination = (Vector3.Cross(playerDir, Vector3.forward) + playerDir);
        direction = destination.normalized;
        //find and set direction
        StartCoroutine("WaitToAttack");
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(waitToAttack);
        direction = Vector3.zero;
        destination = transform.position;

        Attack();
    }


    public override void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude == 0f)
        {
            Friction();
        }

        Accelerate(direction);
    }


    public override void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public override void KnockBack(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    protected override void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        //drop some loot and shieet. 
        //particles!

        Destroy(gameObject);
    }

}
