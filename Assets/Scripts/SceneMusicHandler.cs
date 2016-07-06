using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneMusicHandler : MonoBehaviour {

    public List<AudioClip> songList;
    public AudioSource source;

	// Use this for initialization
	void Start () {
        ChooseRandomSong();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChooseRandomSong()
    {
        source.clip = songList[Random.Range(0, songList.Count)];
        source.Play();
    }
}
