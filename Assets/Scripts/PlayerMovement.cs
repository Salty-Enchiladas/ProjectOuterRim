using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float horizontalTurnAngle;
    public float moveX;
    public float moveY;
    public float moveZ;

    public bool invertVertical;
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontalTurnAngle = -(Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed * 50) * 20;
        horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -45f, 45f);
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        
        moveZ = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.forward, horizontalTurnAngle);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, horizontalTurnAngle);
        }

        if (Input.GetAxis("Vertical") != 0 && invertVertical)           //inverted vertical movement
        {
			moveY = -(Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed / 2));
        }
        else if (Input.GetAxis("Vertical") != 0 && !invertVertical)     //normal vertical movement
        {
            moveY = Input.GetAxis("Vertical") * Time.deltaTime * (playerSpeed / 2);
        }

        transform.position += new Vector3(moveX, moveY, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -50f, 50f), Mathf.Clamp(transform.position.y, -25f, 25f), Mathf.Clamp(transform.position.z, 0f, 0f));
    }
}
