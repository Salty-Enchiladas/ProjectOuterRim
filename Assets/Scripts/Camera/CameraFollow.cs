using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    GameObject playerTarget;
    public float cameraSpeed;
    public Vector3 cameraOffset;
    public bool snapMovement;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerTarget = GameObject.Find("PlayerTarget");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTarget.transform.position.x + cameraOffset.x, playerTarget.transform.position.y + cameraOffset.y, playerTarget.transform.position.z + cameraOffset.z), Time.deltaTime * cameraSpeed);

        if (snapMovement)
        {

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal < -.5)
            {
                cameraOffset.x = 50;
            }
            if (horizontal > .5)
            {
                cameraOffset.x = -50;
            }
            if (vertical < -.5)
            {
                cameraOffset.y = 80;
            }
            if (vertical > .5)
            {
                cameraOffset.y = 0;
            }
        }
    }
}
