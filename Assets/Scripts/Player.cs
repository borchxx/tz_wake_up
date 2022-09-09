using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D rb;
    private Touch _touch;
    private Vector3 _touchPos, _toMovePos;
    private bool _isMoving = false;
    private float _previusDistanceToTouchPos, _currentDistanceToTouchPos;
    
    public event Action PlayerTakeDamage;
    public event Action PlayerTakeBonus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.Bonus.ToString())
        {
            Destroy(col.gameObject);
            PlayerTakeBonus.Invoke();
        }
        if (col.gameObject.tag == Tags.Enemy.ToString())
        {
            Destroy(col.gameObject);
            PlayerTakeDamage.Invoke();
        }
    }

    void Update()
    {
#if UNITY_IOS
        if (_isMoving)
        {
            _currentDistanceToTouchPos = (_touchPos - transform.position).magnitude;
        }

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _previusDistanceToTouchPos = 0;
                _currentDistanceToTouchPos = 0;
                _isMoving = true;
                _touchPos = Camera.main.ScreenToWorldPoint(_touch.position);
                _touchPos.z = 0;
                _toMovePos = (_touchPos - transform.position).normalized;
                rb.velocity = new Vector2(_toMovePos.x * _speed, _toMovePos.y * _speed);
            }
        }

        if (_currentDistanceToTouchPos > _previusDistanceToTouchPos)
        {
            _isMoving = false;
            rb.velocity = Vector2.zero;
        }
        
        if (_isMoving)
        {
            _previusDistanceToTouchPos = (_touchPos - transform.position).magnitude;
        }
#endif
#if UNITY_EDITOR
        
        if (_isMoving)
        {
            _currentDistanceToTouchPos = (_touchPos - transform.position).magnitude;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _previusDistanceToTouchPos = 0;
            _currentDistanceToTouchPos = 0;
            _isMoving = true;
            _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _touchPos.z = 0;
            _toMovePos = (_touchPos - transform.position).normalized;
            rb.velocity = new Vector2(_toMovePos.x * _speed, _toMovePos.y * _speed);
        }
        
        if (_currentDistanceToTouchPos > _previusDistanceToTouchPos)
        {
            _isMoving = false;
            rb.velocity = Vector2.zero;
        }
        
        if (_isMoving)
        {
            _previusDistanceToTouchPos = (_touchPos - transform.position).magnitude;
        }
#endif
    }
}
