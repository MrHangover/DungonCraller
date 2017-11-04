using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy {

    Vector2 destination;
    Vector2 direction;
    public float attackrange;
    public float waitTime = 2f;
    public float attackSpeed = 3f;
    public AnimationCurve attackCurve;

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
        StartCoroutine("AttackAnim");
    }

    IEnumerator AttackAnim()
    {
        Quaternion startRotation = hand.transform.rotation;
        Quaternion wantedRotation = hand.transform.rotation * Quaternion.Euler(0, 0, -90f);

        float t = 0;
        while (t < 1)
        {
            hand.transform.rotation = Quaternion.SlerpUnclamped(startRotation, wantedRotation, attackCurve.Evaluate(t));
            t += Time.deltaTime * attackSpeed;
            yield return new WaitForEndOfFrame();
        }




        //var lookPos = target.position - transform.position;
        //lookPos.y = 0;
        //var rotation = Quaternion.LookRotation(lookPos);
        //rotation *= Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation
        //var adjustRotation = transform.rotation.y + rotationAdjust; //<- this is wrong!
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        StartCoroutine("AttackWait");
    }

    
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(waitTime);
        Attack();
    }



    Vector2 FindDirection()
    {
        destination = player.position;
        if (Vector2.Distance(transform.position, destination) > attackrange)
        {
            direction = (player.position - transform.position).normalized;
        }
        return destination;
    }
    
    
    IEnumerator MoveOverTime()
    {
        
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
