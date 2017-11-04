using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy {

    Vector2 destination;
    public float waitTime = 2f;
    

	// Use this for initialization
	public override void Start ()
    {
   //     AAEMusicLooper.OnBeat += Attack;
        

        base.Start();
        Move(FindDirection());
        Attack();
    }
	
	// Update is called once per frame
	public void Update ()
    {
		
	}

    public override void Attack()
    {
        hand.transform.Rotate(new Vector3(0,0,90f));
        StartCoroutine("AttackWait");
    }
    
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(2f);
        Attack();
    }



    Vector2 FindDirection()
    {
        Vector2 dir = transform.position - player.position;
        destination = dir.normalized * 5f;
        return destination;
    }

    protected override void Move(Vector2 direction)
    {
        StartCoroutine("MoveOverTime");
    }


    IEnumerator MoveOverTime()
    {
        while (Vector2.Distance(transform.position,destination) > 0.2f)
        {
         //   rb.velocity = ;

            yield return new WaitForSeconds(waitTime);

            if(Vector2.Distance(transform.position, destination) <= 0.2f)
            {
                StartCoroutine("WaitMovement");
            }
        }
    }

    IEnumerator WaitMovement()
    {
        StopCoroutine("MoveOverTime");
        yield return new WaitForSeconds(2);
        StartCoroutine("MoveOverTime");
    }



    protected override void KnockBack(Vector2 direction, float force)
    {
        throw new System.NotImplementedException();
    }

    protected override void Damage(float damage)
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }
}
