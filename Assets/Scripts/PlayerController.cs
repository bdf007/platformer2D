using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public TextMeshProUGUI scoreText;

    public int score;

    private bool isGrounded;

    void FixedUpdate () 
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);
        
        if(rig.velocity.x > 0)
        {
            sr.flipX = true;
        } 
        else if (rig.velocity.x < 0)
        {
            sr.flipX = false;
        }
    }   

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // check if the player is falling off the map
        if(transform.position.y < -5)
        {
            GameOver();
        }

        // check if the player is colliding with an enemy
        if (rig.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            GameOver();
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            isGrounded = true;
        }
    }

    //  called when the player collides with an enemy or if the player falls off the map
    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // increase our score and update the UI
    public void AddScore (int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
