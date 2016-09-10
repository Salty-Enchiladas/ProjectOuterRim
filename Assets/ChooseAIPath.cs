using UnityEngine;
using System.Collections;

public class ChooseAIPath : MonoBehaviour
{

	void Start ()
    {
        GetComponent<Animator>().SetFloat("ChooseDirection", Random.Range(.1f, .8f));
	}
	void Update ()
    {
	
	}
}
