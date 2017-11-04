using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBehaviour : MonoBehaviour {

    public Animator animator;

    void Start(){
        AAEMusicLooper.OnBeat += Attack;
    }

    void Attack(){
        animator.SetTrigger("Attack");
    }
}
