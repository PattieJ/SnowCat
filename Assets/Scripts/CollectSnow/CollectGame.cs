using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectGame : MonoBehaviour
{
    private int score;
    private int life;
    private string scorelevel;
    private bool isGameOver;
    public Text ScoreTable;
    public TextMeshProUGUI ScoreLevel;

    public GameObject life1, life2, life3;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        life = 3;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
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

    public void hurt()
    {
        if (life == 3)
        {
            life3.SetActive(false);
            life -= 1;
        }
        else if(life == 2)
        {
            life2.SetActive(false);
            life -= 1;
        }
        else if(life == 1)
        {
            life1.SetActive(false);
            life -= 1;
            isGameOver = true;
        }
    }
}
