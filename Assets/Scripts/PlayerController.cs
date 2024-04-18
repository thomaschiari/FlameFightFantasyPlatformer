using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D body;
    private Animator a;
    private bool isGrounded;
    private bool isStill;
    public int lives = 3;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        isStill = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the player sprite based on the direction they are moving
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }

        // setting animation
        a.SetBool("run", horizontalInput != 0);

        if (horizontalInput == 0)
        {
            isStill = true;
        }
        else
        {
            isStill = false;
        }

        // verificar se o y do player é menor que -10
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed*1.5f);
        isGrounded = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            lives--;
            if (lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public bool canAttack(){
        if (isStill)
        {
            return true;
        }
        return true;
    }
}
