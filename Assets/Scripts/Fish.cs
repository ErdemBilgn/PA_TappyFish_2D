using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float _speed = 9f;

    int _angle;
    int _maxAngle = 20;
    int _minAngle = -60;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);      
        }

        if(_rb.velocity.y > 0) 
        {
            if(_angle <= _maxAngle)
            {
                _angle = _angle + 4;
            }
            ;
        }
        else if(_rb.velocity.y < -2.5f)
        {
            if(_angle > _minAngle) 
            {
                _angle = _angle - 2;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
