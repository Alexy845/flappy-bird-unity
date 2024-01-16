using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FlyFlappy : MonoBehaviour
{
    private float speed = 1.5f;
    private float rotationSpeed = 10f;

    private Rigidbody2D rb2D;
    private bool isDead = false;

    public Score scoreText;
    public Score scorePiece;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2D.velocity = Vector2.up * speed;
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            transform.rotation = Quaternion.Euler(0, 0, rb2D.velocity.y * rotationSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {

            isDead = true;
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            print("Score Up");
            scoreText.ScoreUp();
        }

        if (collision.CompareTag("Piece"))
        {
            print("Score Up");
            scorePiece.ScoreUp();

        }
    }


}
