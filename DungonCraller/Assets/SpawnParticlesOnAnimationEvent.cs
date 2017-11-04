using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticlesOnAnimationEvent : MonoBehaviour {

    public GameObject ParticlesToSpawn;
    public Transform SpawnPosition;

    void SpawnParticles(){
        Instantiate(ParticlesToSpawn, SpawnPosition == null ? transform.position : SpawnPosition.position, Quaternion.identity);
    }
}
