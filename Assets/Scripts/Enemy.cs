using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveOffset;
    private Vector3 startPos;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // are we at the target position?
        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        if (Application.isPlaying)
        {
            from = startPos;
        }
        else
        {
            from = transform.position;
        }
        
        to = from + moveOffset;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(from, to);
        Gizmos.DrawWireSphere(to, 0.2f);
        Gizmos.DrawWireSphere(from, 0.2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.tag == "Player")
        // {
        //     collision.gameObject.GetComponent<PlayerController>().GameOver();
        // }

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().GameOver();
        }
    }
}
