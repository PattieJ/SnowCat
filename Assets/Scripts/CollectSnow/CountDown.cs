using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private CanvasGroup container;

    private bool isCountingDown;
    private float countDownTimer;
    private RandomSnow CreateSnow;
    // Start is called before the first frame update
    void Start()
    {
        isCountingDown = true;
        countDownTimer = 3;
        CreateSnow = GameObject.FindWithTag("GameController").GetComponent<RandomSnow>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountingDown)
        {
            CreateSnow.isBegin = true;
            return;
        }

        countDownTimer -= Time.deltaTime;
        countDownText.gameObject.SetActive(countDownTimer > 0.9f);
        isCountingDown = countDownTimer > 0.9f;

        if (countDownTimer % 1 > 0.5f)
        {
            countDownText.alpha -= Time.deltaTime*2;
        }
        else
        {
            countDownText.alpha += Time.deltaTime*2;
        }

        countDownText.SetText(Mathf.Round(countDownTimer).ToString());
    }
}
