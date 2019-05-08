using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private int points = 0;

    private EnemyManager EnemyMgr;
    private float LoadSceneTime = 3;
    private bool isMatchFinished;
    private float timerLoadScene;
    private FinalScore currentMatchFinalScore;

    public override void Awake()
    {
        base.Awake();
        points = 0;
    }

    private void Start()
    {
        EnemyMgr = EnemyManager.Get();
        currentMatchFinalScore = FinalScore.Get();
    }

    // Update is called once per frame
    private void Update()
    {
        if (EnemyMgr.getEnemiesLeft() <= 0)
        {
            matchFinished();
        }

        if (points <= 0)
        {
            points = 0;
        }
    }

    private void matchFinished()
    {
        isMatchFinished = true;
        currentMatchFinalScore.setFinalScore(points);

        timerLoadScene += Time.deltaTime;

        if (timerLoadScene >= LoadSceneTime)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public bool getMatchStatus()
    {
        return isMatchFinished;
    }

    public int getPoints()
    {
        return points;
    }

    public void addPoints()
    {
        points += 10;
    }

    public void substractPoints()
    {
        points -= 5;
    }
}
