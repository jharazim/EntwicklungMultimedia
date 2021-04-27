using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offsetRotation = target.rotation * new Vector3(0, -2, 5);
        Vector3 camPos = target.position - offsetRotation;
        transform.position = camPos;
        transform.rotation = Quaternion.LookRotation(offsetRotation);
    }
}
