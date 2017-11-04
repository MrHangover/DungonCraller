using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature {

    protected Transform player;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public GameObject hand;

    // Use this for initialization
    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        player = GameManager.Instance.player;

    }

    public virtual void Attack()
    {

    }
    

}
