using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviourSingleton<FinalScore>
{
    private int finalScore;

    public override void Awake()
    {
        base.Awake();
    }

    public int getFinalScore()
    {
        return finalScore;
    }

    public void setFinalScore(int value)
    {
        finalScore = value;
    }
}
