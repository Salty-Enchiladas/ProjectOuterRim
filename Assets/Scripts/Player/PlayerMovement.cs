﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
   // public float forwardSpeed;
    public float maxTurnAngle;
    [HideInInspector]
    public float horizontalTurnAngle;
    public float moveX;
    public float moveY;
    public float moveZ;

    public float clampX;
    public float clampY;

    //public float thrusterRampUpRate;
    //public float thrusterRampDownRate;
    //public float thrusterCooldown;

    GameObject gameManager;
    public bool invertVertical;
    //bool isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive;

    void Start()
    {
       gameManager = GameObject.Find("GameManager");
       playerSpeed = gameManager.GetComponent<PublicVariableHandler>().playerSpeed;
       maxTurnAngle = gameManager.GetComponent<PublicVariableHandler>().maxTurnAngle;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetButton("Thrusters"))
        //{
        //    StartCoroutine(TurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncrease());
        //}

        horizontalTurnAngle = -(Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed * 50) * 20;
        horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -maxTurnAngle, maxTurnAngle);
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;

        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -45, 45), 0f);

        //moveZ = Time.deltaTime * forwardSpeed;

        if (Input.GetAxis("Horizontal") != 0)       // && transform.rotation.z > -45 && transform.rotation.z < 45
        {
            transform.Rotate((Vector3.forward * horizontalTurnAngle * Time.deltaTime) * 7);
            ClampRotation(-maxTurnAngle, maxTurnAngle, 0);
            //transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -horizontalTurnAngle, 0f), Time.deltaTime * 0.3f);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }

        if (invertVertical)           //inverted vertical movement
        {
            moveY = -(Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed / 2));
        }
        else if (!invertVertical)     //normal vertical movement
        {
            moveY = Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed / 2);
        }

        transform.position += new Vector3(moveX, moveY, moveZ);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), Mathf.Clamp(transform.position.y, -clampY, clampY), transform.position.z);

        if (transform.position.x > 9000 || transform.position.x < -9000 || transform.position.y > 6000 || transform.position.y < -6000)
        {
            Camera.main.farClipPlane = 100000;            
        }
    }

    //IEnumerator TurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncrease()
    //{
    //    if (!isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive)
    //    {
    //        isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive = true;

    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(.5f);
    //        forwardSpeed += thrusterRampUpRate;
    //        yield return new WaitForSeconds(3);

    //        forwardSpeed -= thrusterRampDownRate;
    //        yield return new WaitForSeconds(.25f);
    //        forwardSpeed -= thrusterRampDownRate;
    //        yield return new WaitForSeconds(.25f);
    //        forwardSpeed -= thrusterRampDownRate;
    //        yield return new WaitForSeconds(.25f);
    //        forwardSpeed -= thrusterRampDownRate;

    //        yield return new WaitForSeconds(thrusterCooldown);
    //        isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive = false;
    //    }


    //}

    void ClampRotation(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the z axis and rotate it up side down
        float z = transform.rotation.eulerAngles.z - clampAroundAngle;

        z = WrapAngle(z);

        //Move range to [-180, 180]
        z -= 180;

        //Clamp to desired range
        z = Mathf.Clamp(z, minAngle, maxAngle);

        //Move range back to [0, 360]
        z += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z + clampAroundAngle);
    }

    //Make sure angle is within 0,360 range
    float WrapAngle(float angle)
    {
        //If its negative rotate until its positive
        while (angle < 0)
            angle += 360;

        //If its to positive rotate until within range
        return Mathf.Repeat(angle, 360);
    }
}