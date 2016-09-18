using UnityEngine;
using System.Collections;

public class BossLightningGun : MonoBehaviour
{

    public ArcReactor_Launcher launcher;

    private float recharge;
    private bool shooting;
    
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (shooting)
        {
            launcher.LaunchRay();
        }
    }

    IEnumerator Shoot()
    {
        for(int i = 0; i < 5; i++)
        {
            shooting = true;
            yield return new WaitForSeconds(1);
            shooting = false;
            yield return new WaitForSeconds(1);
        }
    }
}