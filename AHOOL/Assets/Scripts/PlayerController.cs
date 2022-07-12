using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D coll;


    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;

    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int item = 0;
    [SerializeField] private Text itemText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private int Enemy = 0;
    [SerializeField] private Text enemyKill;
    [SerializeField] private AudioSource takeItem;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource killEnemy;
    [SerializeField] private AudioSource playerHurt;
    [SerializeField] private int health;
    [SerializeField] private Text healthAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        healthAmount.text = health.ToString();
    }

    private void Update()
    {
        if(state != State.hurt)
        {
            Movement();
        }

        AnimationState();
        animator.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            takeItem.Play();
            Destroy(collision.gameObject);
            item += 1;
            itemText.text = item.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                killEnemy.Play();
                Destroy(other.gameObject);
                Jump();
                Enemy += 1;
                enemyKill.text = Enemy.ToString();
            }
            else
            {
                playerHurt.Play();
                state = State.hurt;
                health -= 1;
                healthAmount.text = health.ToString();
                if(health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (other.gameObject.transform.position.x > transform.position.x){
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-0.2844483f, 0.2844483f);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(0.2844483f, 0.2844483f);
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Footstep()
    {
        footstep.Play();
    }
}
