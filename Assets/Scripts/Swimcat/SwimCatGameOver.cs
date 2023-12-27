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
    public float delayBeforeShowingPanel; // �������ӳ�ʱ��
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
        Debug.Log(slider.value);
        if (slider.value == 0)
        {
            UIMenu.SetActive(false);
            StartCoroutine(ShowPanel(panel));
            
        }
    }
}
