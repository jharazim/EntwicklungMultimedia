using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class btn_movement : MonoBehaviour
{

    bool[] bool_movement;
    public GameObject player;
    private float angle = 0f;
    public float movementspeed;
    // Start is called before the first frame update
    void Start()
    {
        bool_movement = new bool[4];
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for(int i = 0; i < vbs.Length; ++i) {
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
       }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<4; i++) {
            if (bool_movement[i]) {
                switch(i) {
                    case 0:
                        player.transform.Translate(Vector3.back * movementspeed * Time.deltaTime);
                        break;
                    case 1:
                        player.transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
                        break;
                    case 2:
                        angle -= 1f * Time.deltaTime;
                        break;
                    case 3:
                        angle += 1f * Time.deltaTime;
                        break;

                }
            }
        }

        Vector3 lookrotation = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        player.transform.rotation = Quaternion.LookRotation(lookrotation);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        switch(vbb.VirtualButtonName) {
            case "forward_btn":
                bool_movement[1] = true;
                break;
            case "backward_btn":
                bool_movement[0] = true;
                break;
            case "left_btn":
                bool_movement[2] = true;
                break;
            case "right_btn":
                bool_movement[3] = true;
                break;
        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vbb)
    {
        switch(vbb.VirtualButtonName) {
            case "forward_btn":
                bool_movement[1] = false;
                break;
            case "backward_btn":
                bool_movement[0] = false;
                break;
            case "left_btn":
                bool_movement[2] = false;
                break;
            case "right_btn":
                bool_movement[3] = false;
                break;
        }
    }
}
