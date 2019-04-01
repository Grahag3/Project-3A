using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private int speed;
    private Vector3 angle;

    private void Awake()
    {
        angle = Quaternion.Euler(0, 0, Random.Range(0, 360)) * transform.up;
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        transform.Translate(angle * Time.deltaTime * speed);

        
    }

    //private void OnCollisionEnter2D(Collision2D collision)

        
}
