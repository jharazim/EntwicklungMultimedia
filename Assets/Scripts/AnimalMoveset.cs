using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoveset : MonoBehaviour
{
    public Transform myPrefab;
    public float startPosition = 2.5f;
    private Transform[] animal;

    // Start is called before the first frame update
    void Start()
    {
        animal = new Transform[10];
        for (int i=0; i<10; i++) {
            float x = UnityEngine.Random.Range(-4f, 4f);
            float z = UnityEngine.Random.Range(-4f, 4f);
            animal[i] = Instantiate(myPrefab, new Vector3(x, startPosition, z), myPrefab.rotation, this.transform);
            animal[i].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        // Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<10; i++)
        {
            animal[i].Rotate(0, 45 * Time.deltaTime, 0);
        }
    }
}
