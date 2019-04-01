using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotspeed;
    public float speed;
    public Vector3 direction;

    private float min_height = -4.30f;
    private float max_height = 4.30f;

    private float min_width = -8.4f;
    private float max_width = 8.4f;

    private float rotation;
    

    // Start is called before the first frame update
    void Start()
    {
        
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

}
