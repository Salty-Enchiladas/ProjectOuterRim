using UnityEngine;
using System.Collections;

public class BossThrusters : MonoBehaviour
{
    public Light thruster;
    public Light thruster1;
    public Light thruster2;
    public Light thruster3;
    public Light thruster4;
    public Light thruster5;
    public Light thruster6;

    public int intense = 1;
    public bool thrustersOn = false;

    void Update()
    {
        if(thrustersOn == true)
        {
            InvokeRepeating("Intensify", 0f, 1f);
            thruster.intensity = intense;
            thruster1.intensity = intense;
            thruster2.intensity = intense;
            thruster3.intensity = intense;
            thruster4.intensity = intense;
            thruster5.intensity = intense;
            thruster6.intensity = intense;
        }
     
    }

    void Intensify()
    {
        intense++;
    }
}
