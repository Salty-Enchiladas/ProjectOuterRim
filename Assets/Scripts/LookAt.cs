using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
   // public Transform target;    //The ship
    float angle;
    public float factor;
    public float yOffset;
    void Update()
    {
        var dist = (transform.position.z - Camera.main.transform.position.z) * factor;
        Vector3 pos = Input.mousePosition;
        pos.z = dist;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.LookAt(pos);
    }
}
 