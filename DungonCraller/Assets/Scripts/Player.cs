using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public float reach = 1f;
    public GameObject fistPrefab;

    GameObject weaponObject;
    Weapon weapon;
    Transform hand;
    BoxCollider2D boxCollider;
    Rigidbody2D body;

    private void Start()
    {
        hand = Instantiate(new GameObject("Hand"), transform).transform;
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        EquipFist();
    }

    private void Update()
    {

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
        if(direction.sqrMagnitude == 0f)
        {
            Friction();
        }

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

    public void Attack(Vector2 normalizedAttackPosition)
    {
        Vector2 wantedPosition = new Vector2(transform.position.x, transform.position.y) + normalizedAttackPosition * reach;
        Vector2 handPosition = new Vector2(hand.position.x, hand.position.y);

        //!Apply friction. Make it constant for now.
        Vector2 startNormalizedVelocity = weapon.velocity.normalized;
        float friction = Time.deltaTime * 5f;
        weapon.velocity -= weapon.velocity * friction;
        if(weapon.velocity.normalized != startNormalizedVelocity)
        {
            weapon.velocity = Vector2.zero;
        }

        //!Apply force to weapon based on it's weight, weightscale, the players strength, and distance to target. Don't use drag yet. Drag might be useful for friction.
        float distance = 2f * Mathf.Max(0.3f, Vector2.Distance(hand.position, wantedPosition));
        float force = (strength - (weapon.weight * weapon.weightScale)) * distance * Time.deltaTime;
        weapon.velocity += force * (wantedPosition - handPosition).normalized;

        //!Limit weapon speed to max velocity.
        float velocityMagnitude = weapon.velocity.magnitude;
        if(velocityMagnitude > weapon.maxSpeed)
        {
            Vector2 normalizedVelocity = weapon.velocity.normalized;
            weapon.velocity = normalizedVelocity * weapon.maxSpeed;
        }

        //!Change position based on velocity
        hand.position += new Vector3(weapon.velocity.x, weapon.velocity.y, hand.position.z) * Time.deltaTime;

        //Limit reach
        Vector2 transformPosition = new Vector2(transform.position.x, transform.position.y);
        handPosition = new Vector2(hand.position.x, hand.position.y);
        Vector2 relativeHandPosition = transformPosition - handPosition;
        if(relativeHandPosition != Vector2.zero && 
            relativeHandPosition.sqrMagnitude > (relativeHandPosition.normalized * reach).sqrMagnitude)
        {
            handPosition = transformPosition - relativeHandPosition.normalized * reach;
            hand.position = new Vector3(handPosition.x, handPosition.y, hand.position.z);
            //If velocity tries to go outside the reach, apply the velocity to the player, based on weapon and player weight.
            Vector2 velocityToAdd = weapon.velocity * (weapon.weight / weight);
            body.velocity += weapon.velocity * (weapon.weight / weight) * Time.deltaTime;

            //Limit player velocity to weapon velocity
            if((body.velocity + velocityToAdd).sqrMagnitude > weapon.velocity.sqrMagnitude)
            {
                velocityToAdd = weapon.velocity - (body.velocity + velocityToAdd);
            }
        }

        hand.right = hand.position - transform.position;
    }

    public void DropWeapon()
    {

    }

    public void EquipWeapon(GameObject weapon)
    {
        this.weapon = weapon.GetComponent<Weapon>();
        if(this.weapon == null)
        {
            Debug.LogError("Wow really? You can't equip a weapon that doesn't have any Weapon script, cmon dude...");
            EquipFist();
            return;
        }

        //TODO equip weapon
    }

    void EquipFist()
    {
        weaponObject = Instantiate(fistPrefab, hand.position, hand.rotation, hand);
        weaponObject.name = "Fist";
        weapon = weaponObject.GetComponent<Weapon>();
    }
}
