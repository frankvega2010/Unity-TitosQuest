using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFinalScore : MonoBehaviour
{
    public Text finalScoreText;

    private FinalScore lastMatchFinalScore;
    // Start is called before the first frame update
    void Start()
    {
        lastMatchFinalScore = FinalScore.Get();
        finalScoreText.text = "Your score is : " + lastMatchFinalScore.getFinalScore();
    }
}
