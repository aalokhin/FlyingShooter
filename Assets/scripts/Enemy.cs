using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.001f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform groupingParent; //allows to organize enemies in runtime and get rid of destroyed objects 

    ParticleSystem explosionParticles;
    private void Start() {
       explosionParticles = GetComponentInChildren<ParticleSystem>();
    }


    private void OnParticleCollision(GameObject other) {
       // explosionSequence();
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = groupingParent;
        Destroy(gameObject);

    }
     
    private void OnCollisionEnter(Collision other) {
        explosionParticles.Play();
        Destroy(gameObject);        
    }

}
