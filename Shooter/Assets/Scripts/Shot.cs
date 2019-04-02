using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public static int score = 0;
    public Text score_ui;



    public float shot_speed;
    // Start is called before the first frame update
    void Start()
    {
        score_ui.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * shot_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
       
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            Sounds.play_sound("Explosion41");

            score += 10;
            score_ui.text = "Score: " + score.ToString();
        }
       
    }
}
