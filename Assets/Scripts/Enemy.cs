using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int speed;
    private int _randomValue;
    private void Start()
    {
        GetRandomValue();
    }

    private void GetRandomValue()
    {
        _randomValue = Random.Range(1, 4);
        StartCoroutine(Countdown(1));
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.Water.ToString())
        {
            if (_randomValue == 1)
            {
                _randomValue = 3;
            }
            else if (_randomValue == 2)
            {
                _randomValue = 4;
            }
            else if (_randomValue == 3)
            {
                _randomValue = 2;
            }
            else if (_randomValue == 4)
            {
                _randomValue = 2;
            }
        }
    }

    IEnumerator Countdown (int seconds) {
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
        }
        GetRandomValue();
    }

    private void Move()
    {
        if (_randomValue == 1)
        {
            transform.position += transform.up * (Time.deltaTime * speed);
        }
        else if (_randomValue == 2)
        {
            transform.position += transform.right * (Time.deltaTime * speed);
        }
        else if (_randomValue == 3)
        {
            transform.position += -transform.up * (Time.deltaTime * speed);
        }
        else if (_randomValue == 4)
        {
            transform.position += -transform.right * (Time.deltaTime * speed);
        }
    }
}


enum Tags
{
    Enemy,
    Water,
    Bonus
}
