using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubShot : MonoBehaviour
{
    public int score;

    private Vector3 angle;
    public Text score_ui;

    public float shot_speed;

    // Start is called before the first frame update
    void Start()
    {
        angle = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.up;
        score = PlayerPrefs.GetInt("current score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(angle * Time.deltaTime * shot_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {

            Sounds.play_sound("Explosion41");

            score += 10;
            PlayerPrefs.SetInt("current score", score);
            //score_ui.text = "Score: " + score.ToString();

            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }
    }
}
