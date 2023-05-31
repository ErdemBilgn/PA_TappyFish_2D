using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float _speed = 9f;

    int angle;
    int maxAngle = 20;
    int minAngle = -60;

    public Score score;

    bool touchedGround;

    public GameManager gameManager;
    public Sprite fishDied;

    SpriteRenderer sp;
    Animator anim;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        FishSwim();
        
    }

    void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }

        }
        else if (_rb.velocity.y < -2.5f)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }
        if(!touchedGround)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if(collision.CompareTag("Column"))
        {
            // game over state.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                // game over state.
                gameManager.GameOver();
                GameOverFish();
            }
        }
    }

    void GameOverFish()
    {
        touchedGround = true;
        anim.enabled = false;
        sp.sprite = fishDied;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
