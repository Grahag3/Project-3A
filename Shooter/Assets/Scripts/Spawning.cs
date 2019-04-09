using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawning : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject container;

    private int randomgen;
    private int randomgen1;

    private int speed;

    public static int time = 30;
    public Text time_ui;

    public GameObject shot;
    public Transform shot_spawn;
    public float fire_rate;
    private float next_shot;


    // private GameObject score_ref = GameObject.Find("Score");

  

    private void SpawnObject()
    {
        randomgen = Random.Range(1, 3);

        if (randomgen == 1)
        {
            randomgen1 = Random.Range(3, 5);

            if (randomgen1 == 3)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(-10.40f, Random.Range(4.30f, -4.30f)), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

            if (randomgen1 == 4)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(10.40f, Random.Range(4.30f, -4.30f)), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }


        }

        if (randomgen == 2)
        {
            randomgen1 = Random.Range(3, 5);

            if (randomgen1 == 3)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(Random.Range(8.40f, -8.40f), -6.3f), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

            if (randomgen1 == 4)
            {
                GameObject asteroid_instance = Instantiate(asteroid, new Vector3(Random.Range(8.40f, -8.40f), 6.3f), Quaternion.identity);

                asteroid_instance.transform.SetParent(container.transform);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 0.5f);

        time_ui.text = "Time: " + time.ToString();

        InvokeRepeating("Count", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > next_shot)
        {
            if (shot_spawn != null){

                next_shot = Time.time + fire_rate;

                GameObject shot_instance = Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
                shot_instance.GetComponent<Shot>().score_ui = GameObject.FindWithTag("Score").GetComponent<Text>();

                Sounds.play_sound("Laser_Shoot36");
            }
            
            else if (GameObject.Find("Player(Clone)") == true)
            {
                shot_spawn = GameObject.Find("Player(Clone)").transform.GetChild (1).GetComponent<Transform>();

                Sounds.play_sound("Laser_Shoot36");
            }

            else
            {
                shot_spawn = GameObject.Find("Player(Clone)(Clone)").transform.GetChild(1).GetComponent<Transform>();

                Sounds.play_sound("Laser_Shoot36");
            }
        }
    }

    void Count()
    {
        time -= 1;
        PlayerPrefs.SetInt("Current Time", time);
        time_ui.text = "Time: " + time.ToString();

        if (time == 0)
        {
            SceneManager.LoadScene("Ending");
            time = 30;
            Player.lives = 3;
        }
    }
}
   

