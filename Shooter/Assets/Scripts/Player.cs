using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotspeed;
    public float speed;
    public Vector3 direction;



    private float rotation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotdirection = (Input.GetAxis("Horizontal"));
        rotation = (rotdirection* rotspeed);

        transform.Rotate(0, 0, -rotation);

        direction = transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
    }
}
