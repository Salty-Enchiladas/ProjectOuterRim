using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour
{
    public AudioSource laserSound;

    AudioClip noLevelSound;
    AudioClip level1Sound;
    AudioClip level2Sound;
    AudioClip level3Sound;

    void Start()
    {
        //Code for setting sounds from handler


        laserSound.clip = noLevelSound;
    }

    public void Shooting()
    {
        laserSound.Play();
    }

    public void Level1()
    {
        laserSound.clip = level1Sound;
    }

    public void Level2()
    {
        laserSound.clip = level2Sound;
    }

    public void level3()
    {
        laserSound.clip = level3Sound;
    }

    public void lostLevel()
    {

    }

}
