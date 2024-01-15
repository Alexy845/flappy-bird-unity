using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyFlappy : MonoBehaviour
{

    // Start is called before the first frame update
    private float speed = 1.5f;
    private float rotationSpeed = 10f;

    private Rigidbody2D rb2D;
    void Start()
    {
     rb2D = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2D.velocity = Vector2.up * speed;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, rb2D.velocity.y * rotationSpeed);
    }
}
