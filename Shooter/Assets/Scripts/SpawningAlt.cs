using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAlt : MonoBehaviour
{
    public GameObject enemy_ship;
    public GameObject container;

    private int randomgen;

    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Current Time") == 15)
        {
            if (!once)
            {
                InvokeRepeating("SpawnEnemy", 0, 2);
                once = true;
            }
            
        }
    }

    private void SpawnEnemy()
    {
        randomgen = Random.Range(1, 5);

        if (randomgen == 1)
        {
            GameObject enemy_instance = Instantiate(enemy_ship, new Vector3(Random.Range(-9.0f, 9.0f), -5.5f), Quaternion.Euler(0,0,0));
            enemy_instance.transform.SetParent(container.transform);
        }
        if (randomgen == 2)
        {
            GameObject enemy_instance = Instantiate(enemy_ship, new Vector3(Random.Range(-9.0f, 9.0f), 5.5f), Quaternion.Euler(0,0,180));
            enemy_instance.transform.SetParent(container.transform);
        }
        if (randomgen == 3)
        {
            GameObject enemy_instance = Instantiate(enemy_ship, new Vector3(-9.0f, Random.Range(-5.5f, 5.5f)), Quaternion.Euler(0,0,-90));
            enemy_instance.transform.SetParent(container.transform);
        }
        if (randomgen == 4)
        {
            GameObject enemy_instance = Instantiate(enemy_ship, new Vector3(9.0f, Random.Range(-5.5f, 5.5f), 9.0f), Quaternion.Euler(0,0,90));
            enemy_instance.transform.SetParent(container.transform);
        }
    }


}
