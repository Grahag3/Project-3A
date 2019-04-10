using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScatterShot : MonoBehaviour
{
    public GameObject sub;
    private Vector3 space;

    public Text score_ui;
    public int score;

    public float shot_speed;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("current score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        space = gameObject.transform.position;
        transform.Translate(Vector3.up * Time.deltaTime * shot_speed);
        Invoke("Detonate", 1);
    }

    private void Detonate()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject sub_shot = Instantiate(sub, space, Quaternion.identity);
            sub_shot.transform.name = "sub_" + i;
        }
        Sounds.play_sound("Laser_Shoot36");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {

            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            Sounds.play_sound("Explosion41");

            score += 10;
            PlayerPrefs.SetInt("current score", score);
            score_ui.text = "Score: " + score.ToString();

        }
    }
}