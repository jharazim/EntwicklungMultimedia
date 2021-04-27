using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private float horizontalSpeed = 4;
    private float verticalSpeed = 10;
    private float angel = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        angel += moveHorizontal * horizontalSpeed * Time.deltaTime;
        Vector3 targetDirection = new Vector3(Mathf.Sin(angel), 0, Mathf.Cos(angel));
        this.transform.rotation = Quaternion.LookRotation(targetDirection);

        this.transform.position += targetDirection * moveVertical * verticalSpeed * Time.deltaTime;
        //this.transform.Rotate(0, moveHorizontal * verticalSpeed * Time.deltaTime, 0);

        //UnityEngine.Debug.Log(moveHorizontal);
    }
}
