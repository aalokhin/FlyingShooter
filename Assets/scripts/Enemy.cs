using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.001f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    ParticleSystem explosionParticles;
    private void Start() {
       explosionParticles = GetComponentInChildren<ParticleSystem>();
    }


    private void OnParticleCollision(GameObject other) {
       // explosionSequence();
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
       // vfx.transform.parent = parent;
        Destroy(gameObject);

    }
     
    private void OnCollisionEnter(Collision other) {
        explosionSequence();
    }


    void die(){
        Destroy(gameObject);        
    }

    void explosionSequence(){
         
        explosionParticles.Play();
        Invoke("die", loadDelay);

    }
}
