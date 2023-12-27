using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectGame : MonoBehaviour
{
    private int score;
    private string scorelevel;
    private bool isGameOver;
    public Text ScoreTable;
    public TextMeshProUGUI ScoreLevel;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scorelevel = "";
        isGameOver = false;
        ScoreTable.text = "" + score;
        ScoreLevel.GetTextInfo("");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreTable();
        UpdateScoreLevel();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void GetScoreLevel(string getScorelevel)
    {
        scorelevel = getScorelevel;
    }

    private void UpdateScoreTable()
    {
        ScoreTable.text = "" + score;
    }

    private void UpdateScoreLevel()
    {
        ScoreLevel.GetTextInfo(scorelevel);
    }

    public void GameOver()
    {

    }
}
