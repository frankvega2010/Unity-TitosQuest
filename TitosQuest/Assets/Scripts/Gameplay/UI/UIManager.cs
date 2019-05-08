using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public Text EnemiesLeft;
    public Text Points;
    public Text finish;

    private Vector4 oldPanelColor;
    private EnemyManager EnemyMgr;
    private GameManager GameMgr;
    private Image UIPanel;

    // Start is called before the first frame update
    private void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        EnemyMgr = EnemyManager.Get();
        GameMgr = GameManager.Get();
        finish.text = "";
        UIPanel = panel.GetComponent<Image>();
        UIPanel.color = new Vector4(0, 0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        EnemiesLeft.text = "Enemies left: " + EnemyMgr.getEnemiesLeft();
        Points.text = "Points: " + GameMgr.getPoints();
        if(GameMgr.getMatchStatus())
        {
            finish.text = "Match Finished!";
            finish.color = Color.green;
            UIPanel.color = oldPanelColor;
        }
    }
}
