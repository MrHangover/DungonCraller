using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public PlayerMovementData movementData;

    private bool isGrounded;
    private Vector2 velocity;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Friction(velocity);
        //TODO raycast physics, save info, use for functions and collision

        Accelerate(velocity);
	}

    /// <summary>
    /// Applies friction. Duh.
    /// </summary>
    /// <param name="velocity"></param>
    Vector2 Friction(Vector2 velocity)
    {
        //TODO apply friction
        if (isGrounded)
        {

        }
        else
        {

        }
        return velocity;
    }

    /// <summary>
    /// Accelerates the player
    /// </summary>
    /// <param name="velocity"></param>
    Vector2 Accelerate(Vector2 velocity)
    {
        //TODO fill method
        return velocity;
    }

    public void Move(Vector2 input)
    {

    }
}
