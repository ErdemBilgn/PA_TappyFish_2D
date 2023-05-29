using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLeftMovement : MonoBehaviour
{

    [SerializeField] float _speed;
    BoxCollider2D box;
    float groundWidth;
    float obstacleWidth;

    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }


    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if(gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }

        if(gameObject.CompareTag("Obstacle"))
        {
            if(transform.position.x <= GameManager.bottomLeft.x - obstacleWidth)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
