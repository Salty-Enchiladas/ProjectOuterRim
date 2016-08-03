using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float forwardSpeed;
    public float horizontalTurnAngle;
    public float moveX;
    public float moveY;
    public float moveZ;

    public float clampX;
    public float clampY;

    public float thrusterRampUpRate;
    public float thrusterRampDownRate;
    public float thrusterCooldown;

    public bool invertVertical;
    bool isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive;

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetButton("Thrusters"))
        //{
        //    StartCoroutine(TurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncrease());
        //}

        horizontalTurnAngle = -(Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed * 50) * 20;
        horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -45f, 45f);
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;

        //moveZ = Time.deltaTime * forwardSpeed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.forward, horizontalTurnAngle);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, horizontalTurnAngle);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
        if (invertVertical)           //inverted vertical movement
        {
            moveY = -(Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed));
        }
        else if (!invertVertical)     //normal vertical movement
        {
            moveY = Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed);
        }

        transform.position += new Vector3(moveX, moveY, moveZ);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), Mathf.Clamp(transform.position.y, -clampY, clampY), transform.position.z);
    }

    IEnumerator TurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncrease()
    {
        if (!isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive)
        {
            isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive = true;

            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(.5f);
            forwardSpeed += thrusterRampUpRate;
            yield return new WaitForSeconds(3);

            forwardSpeed -= thrusterRampDownRate;
            yield return new WaitForSeconds(.25f);
            forwardSpeed -= thrusterRampDownRate;
            yield return new WaitForSeconds(.25f);
            forwardSpeed -= thrusterRampDownRate;
            yield return new WaitForSeconds(.25f);
            forwardSpeed -= thrusterRampDownRate;

            yield return new WaitForSeconds(thrusterCooldown);
            isTurboThrusterBoosterSuperMegaTurboThrusterBoosterSuperMegaSpeedIncreaseActive = false;
        }


    }
}