using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToGive;
    public float bobHeight;
    public float bobSpeed;

    private float startYPos;

    void Start ()
    {
        startYPos = transform.position.y;
    }

    void Update ()
    {
        float newY = startYPos + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // increase the score, then destroy the coin
            collision.GetComponent<PlayerController>().AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }
}
