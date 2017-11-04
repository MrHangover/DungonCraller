using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public float reach = 1f;
    public GameObject fistPrefab;

    GameObject weapon;
    Weapon weaponData;
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
        hand.position = wantedPosition;
        hand.right = hand.position - transform.position;
    }

    public void DropWeapon()
    {

    }

    public void EquipWeapon(GameObject weapon)
    {
        weaponData = weapon.GetComponent<Weapon>();
        if(weaponData == null)
        {
            Debug.LogError("Wow really? You can't equip a weapon that doesn't have any Weapon script, cmon dude...");
            EquipFist();
            return;
        }

        //TODO equip weapon
    }

    void EquipFist()
    {
        weapon = Instantiate(fistPrefab, hand.position, hand.rotation, hand);
        weapon.name = "Fist";
        weaponData = weapon.GetComponent<Weapon>();
    }
}
