﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBehaviour : MonoBehaviour {

    public Animator animator;

    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            animator.SetTrigger("Attack");
        }
    }
}
