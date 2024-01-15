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

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // V�rifiez si le joueur est mort, si oui, ignorez les entr�es
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
        // V�rifiez si le joueur est mort, si oui, ignorez les rotations
        if (!isDead)
        {
            transform.rotation = Quaternion.Euler(0, 0, rb2D.velocity.y * rotationSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // Marquez le joueur comme mort
            isDead = true;

            // Vous pouvez �galement d�sactiver d'autres composants ou effectuer d'autres actions ici si n�cessaire

            // Retardez le chargement de la sc�ne pour laisser le temps � l'animation de mort de jouer
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        // Attendez quelques secondes avant de charger la sc�ne suivante
        yield return new WaitForSeconds(2f);

        // Chargez la sc�ne suivante
        SceneManager.LoadScene(1);
    }
}
