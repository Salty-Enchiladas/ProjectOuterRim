using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed;
    public float yLimit;
    public float zLimit;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + yLimit, player.transform.position.z - zLimit), Time.deltaTime * cameraSpeed);
	}
}
