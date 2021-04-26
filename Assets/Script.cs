using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
	public Transform myPrefab;
    private Transform[] test;
    public float speed = 1f;
    private bool speedup = true;
    private bool speedpositive = true;
    // Start is called before the first frame update
    void Start()
    {
        test = new Transform[10];
		for (int i=0; i<10; i++) {
			float x = UnityEngine.Random.Range(-4f, 4f);
			float z = UnityEngine.Random.Range(-4f, 4f);
			test[i] = Instantiate(myPrefab, new Vector3(x, 0, z), Quaternion.identity);
		}
		// Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<10; i++)
        {
            if (test[i].position.y < 0 || test[i].position.y >= 1)
            {
                speedup = true;
                if (test[i].position.y < 0)
                {
                    speedpositive = true;
                } else if (test[i].position.y >= 1)
                {
                    speedpositive = false;
                }
            } else if ((test[i].position.y >= 0.5 && speedpositive) || (test[i].position.y < 0.5 && !speedpositive))
            {
               // UnityEngine.Debug.Log("BUP");
                speedup = false;
            }

            Vector3 position;
            position = test[i].transform.position;
            if (speedup)
            {
                speed = speed * 1.002f;
            } else
            {
                speed = speed / 1.002f;
            }

            if (speed >= 3f)
            {
                speed = 3f;
            } else if (speed <= 1f)
            {
                speed = 1f;
            }

            if (speedpositive)
            {
                test[i].position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            else
            {
                test[i].position += new Vector3(0, (0 - speed), 0) * Time.deltaTime;
            }
            //UnityEngine.Debug.Log(test[0].position.y);
            //UnityEngine.Debug.Log(speed);

            //test[i].Rotate(new Vector3(1f, 0f, 0f), 0.8f, Space.Self);
            test[i].Rotate(0, 1, 0);
            //transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
        }
    }
}
