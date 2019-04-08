using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject player;
    public float rotspeed;
    public float speed;
    public Vector3 direction;

    private float min_height = -4.30f;
    private float max_height = 4.30f;

    private float min_width = -8.4f;
    private float max_width = 8.4f;

    private float rotation;

    public Text lives_ui;

    public static int lives = 3;

    private Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);
    

    // Start is called before the first frame update
    void Start()
    {
        lives_ui.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float rotdirection = (Input.GetAxis("Horizontal"));
        rotation = (rotdirection * rotspeed);

        transform.Rotate(0, 0, -rotation);

        direction = transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(direction * speed);

            
        }

        if ((transform.position.y) < min_height)
        {
            transform.position = new Vector3(transform.position.x, min_height, 0);
        }

        if ((transform.position.y) > max_height)
        {
            transform.position = new Vector3(transform.position.x, max_height, 0);
        }

        if ((transform.position.x) < min_width)
        {
            transform.position = new Vector3(min_width, transform.position.y, 0);
        }

        if ((transform.position.x) > max_width)
        {
            transform.position = new Vector3(max_width, transform.position.y, 0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //transform.position = origin;
        Instantiate(player, origin, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(collision.gameObject);

        


        lives -= 1;
        lives_ui.text = "Lives: " + lives.ToString();

        if (lives == 0)
        {
            Shot.score = 0;
            SceneManager.LoadScene("Ending");
            lives = 3;
            Spawning.time = 30;
        }

        GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");

        foreach (GameObject asteroid in asteroids)
        {
            GameObject.Destroy(asteroid);
        }
        Sounds.play_sound("Explosion41");
    }
}
