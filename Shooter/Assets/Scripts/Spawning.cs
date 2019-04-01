using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject container;

    private int randomgen;
    private int randomgen1;


    private void SpawnObject()
    {
        randomgen = Random.Range(1, 3);

        if (randomgen == 1)
        {
            randomgen1 = Random.Range(3, 5);

            if (randomgen1 == 3)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(-8.40f, Random.Range(4.30f, -4.30f)), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

            if (randomgen1 == 4)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(8.40f, Random.Range(4.30f, -4.30f)), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }


        }

        if (randomgen == 2)
        {
            randomgen1 = Random.Range(3, 5);

            if (randomgen1 == 3)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(Random.Range(8.40f, -8.40f), -4.3f), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

            if (randomgen1 == 4)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(Random.Range(8.40f, -8.40f), 4.3f), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
   

