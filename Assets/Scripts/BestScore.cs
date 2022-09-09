using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BestScore", menuName = "ScriptableObjects/BestScoreScriptableObject", order = 1)]
public class BestScore : ScriptableObject
{
    public int Score
    {
        get
        {
            return _bestScore;    
        }
        set
        {
            _bestScore = value;
        }
    }
    private int _bestScore;
}
