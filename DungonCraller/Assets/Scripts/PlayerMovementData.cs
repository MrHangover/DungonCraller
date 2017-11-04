using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementData : ScriptableObject
{
    public float acceleration;
    public float airAcceleration;
    public float maxSpeed;
    public float friction;
    public float airFriction;
    public float jumpForce;
    public float maxJumpTime;
    public float gravity;
}
