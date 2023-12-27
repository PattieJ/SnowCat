using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwimCatGameOver : MonoBehaviour
{
    public AnimationCurve showCurve;
    public float animationSpeed;
    public GameObject panel;
    public GameObject UIMenu;
    public Slider slider;
    public float delayBeforeShowingPanel; // 新增的延迟时间
    public FishGenerator fishGenerator;
    private int fishNum = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text overText;

    IEnumerator ShowPanel(GameObject gameObject)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
        Time.timeScale = (0);
    }


    private void Update()
    {
        fishNum = fishGenerator.fish_count();
        //Debug.Log(slider.value);
        if (fishNum == 50 || slider.value == 0)
        {
            UIMenu.SetActive(false);
            overText.text = scoreText.text;
            StartCoroutine(ShowPanel(panel));
        }
    }
}
