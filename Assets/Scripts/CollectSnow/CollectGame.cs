using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;


public class CollectGame : MonoBehaviour
{
    private int score;
    private int life;
    private string scorelevel;
    private int score_all;
    public bool isGameOver;
    public Text ScoreTable;
    public TextMeshProUGUI ScoreLevel;

    public GameObject life1, life2, life3;
    public GameObject Menu;
    public GameObject GameOverMask;
    public GameObject star1, star2, star3;

    public ParticleSystem snowy;

    [SerializeField] private TMP_Text GameOverText;
    [SerializeField] private TMP_Text ShowScoreText;




    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score_all = 0;
        life = 3;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        scorelevel = "";
        isGameOver = false;
        ScoreTable.text = "" + score;
        ScoreLevel.GetTextInfo("");
        GameOverText.SetText("");
        ShowScoreText.SetText("");
        GameOverMask.SetActive(false);
        Menu.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreTable();
        UpdateScoreLevel();
        if (score_all > 50000) isGameOver = true;
        if (isGameOver)
        {
            GameOver();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void CountScoreAll(int snowscore)
    {
        score_all += snowscore;
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
        GameOverMask.SetActive(true);
        Menu.SetActive(false);
        star1.SetActive(true);
        ShowScoreText.SetText("Score:" + score.ToString() + "/" + score_all.ToString());
        snowy.Pause();
        if (life > 0)
        {
            GameOverText.SetText("Finished!");
        }
        else
        {
            GameOverText.SetText("Game Over");
            return;
        }
        if (1f * score / score_all > 0.7)
        {
            star2.SetActive(true);
        }
        if(1f * score / score_all > 0.9)
        {
            star3.SetActive(true);
        }
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
