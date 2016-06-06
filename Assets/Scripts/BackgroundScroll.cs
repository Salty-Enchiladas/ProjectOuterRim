using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0f, Time.time * scrollSpeed));
    }
}
