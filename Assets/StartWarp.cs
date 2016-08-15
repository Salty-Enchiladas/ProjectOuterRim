using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartWarp : MonoBehaviour 
{
    void Start()
    {
        StartCoroutine(Waiting());
    }
	IEnumerator Waiting()
	{
        yield return new WaitForSeconds(4);
			GetComponent<Animator> ().SetBool ("Open", true);
        yield return new WaitForSeconds(10);
			StartWarping ();
	}

	void StartWarping()
	{
		Camera.main.fieldOfView++;
        StartCoroutine(Ramping());
    }

    IEnumerator Ramping()
    {
        yield return new WaitForSeconds(.01f);
        if (Camera.main.fieldOfView != 179)
            StartWarping();
        else if (Camera.main.fieldOfView == 179)
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
