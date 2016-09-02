using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserOverheat : MonoBehaviour
{
    public Image heatBar;
    GameObject player;
    GameObject gun;
    FireScript fireScript;

    float yPos;
	void Start ()
    {
        player = GameObject.Find("Player");
        gun = player.GetComponent<StoreVariables>().lasers[0];
        fireScript = gun.GetComponent<FireScript>();
        
    }

    void Update()
    {
        heatBar.color = Color.Lerp(heatBar.color, Color.clear, fireScript.heatLevel / 100 * Time.deltaTime);
    }
}
