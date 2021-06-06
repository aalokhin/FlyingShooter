using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] float speed = 25f;
    [SerializeField] float xRange = 1.5f;
    [SerializeField] float yRange = 2.5f;
    [SerializeField] float rawXPos, rawYPos;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;
    void Update()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
       // Debug.Log("delta time is " + Time.deltaTime);

        processRotation();
        processTranslation();
        processFiring();
    }

    // Vector3 positionInNMoment(Vector3 initialPos, float deltaTime){
    //     float zPos = initialPos.localPosition.z;
    //     float acceleration = 0.1f;
    //     float impulse = 1;

    //     while(deltaTime>0){
    //         zPos = zPos + (impulse - acceleration);
    //         impulse-=acceleration;
    //         deltaTime-=1;
    //     }
    //     Debug.Log("here we go zpos" + zPos);

    //     return Vector3(0,0,zFin);

    // }

    void processFiring(){
        if(Input.GetKey(KeyCode.Space)){
            activateLasers(true);
        }
        else{
            activateLasers(false);
        }
    }

    void activateLasers(bool shouldBeActive){

        foreach (GameObject laser in lasers)
        {
            laser.SetActive(shouldBeActive);
            //laser.GetComponent<ParticleSystem>().emission.enabled();


            // var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            // emissionModule.enabled = shouldBeActive;

        }

    }

    void processRotation(){
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;

        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);


    }

    void processTranslation(){

        float xOffset = speed * xThrow * Time.deltaTime;
        rawXPos = xOffset + transform.localPosition.x;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        float yOffset = speed * yThrow * Time.deltaTime;
        rawYPos = yOffset + transform.localPosition.y;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition =  new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }
}
