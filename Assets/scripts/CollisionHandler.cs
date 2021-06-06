using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    private void OnCollisionEnter(Collision other) {

        //Destroy(other);

        
        StartCrashSequence();    
        //Debug.Log(this.name + "--Collided with--" + other.gameObject.name); 
    }

    void StartCrashSequence()
    {
        ParticleSystem explosionParticles = gameObject.GetComponentInChildren<ParticleSystem>();
        explosionParticles.Play();
        //crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
       // GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);


       // GetComponent<PlayerControls>().enabled = false;
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
