using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _bonus;
    private Vector2 objPos;
    void Start()
    {
        objPos = new Vector2(gameObject.transform.position.x + gameObject.transform.localScale.x / 2, gameObject.transform.position.y + gameObject.transform.localScale.y / 2);

        var chance = Random.Range(0, 10);
        if (chance >= 3)
        {
            if (chance <= 7)
            { 
                Instantiate(_enemy, objPos, Quaternion.identity);
            }
            else
            {
                Instantiate(_bonus, objPos, Quaternion.identity);
            }
        }
    }
}
