using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies_move : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool MoveRight;

    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && !collision.collider.CompareTag("Player"))
        {
            MoveRight = !MoveRight;
        }

        if (MoveRight)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
