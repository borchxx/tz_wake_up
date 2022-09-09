using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GeneratePlane : MonoBehaviour
{
    [SerializeField] private GameObject _planeCell;
    [SerializeField] private GameObject _waterCell;
    public int widht;
    public int heigh;
    private List<GameObject> _planeList;
    public void Generate()
    {
        for (int y = 0; y < heigh; y++)
        {
            for (int x = 0; x < widht; x++)
            {
                if (y == 0 || y == heigh-1)
                {
                    Instantiate(_waterCell, new Vector2(x*5, y*5), Quaternion.identity);
                }
                else if (x == 0 || x == heigh-1)
                {
                    Instantiate(_waterCell, new Vector2(x*5, y*5), Quaternion.identity);
                }
                else
                {
                    Instantiate(_planeCell, new Vector2(x*5, y*5), Quaternion.identity);
                }
            }
        }
    }

    public void Remove()
    {
        _planeList = new List<GameObject>();
    }
}
