using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGame : MonoBehaviour
{
    private int score;
    private bool isGameOver;
    public Text ScoreTable;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
        ScoreTable.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreTable();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    private void UpdateScoreTable()
    {
        ScoreTable.text = "" + score;
    }

    public void GameOver()
    {

    }
}
