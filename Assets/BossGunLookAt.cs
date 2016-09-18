using UnityEngine;
using System.Collections;

public class BossGunLookAt : MonoBehaviour
{
    GameObject player;
    GameObject colliders;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        colliders = player.transform.FindChild("PlayerTarget").gameObject;
	}
	
	void Update ()
    {
        transform.LookAt(player.transform);
	}
}
