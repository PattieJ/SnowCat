using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour
{
    public Image imageToShow1;
    public Image imageToShow2;
    void Start()
    {
        imageToShow2.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightArea"))
        {
            Debug.Log("1");
            imageToShow1.gameObject.SetActive(true); // ��ʾ��һ��Image
            imageToShow2.gameObject.SetActive(false); // ���صڶ���Image
        }
        if (other.CompareTag("DownArea"))
        {
            Debug.Log("2");
            imageToShow1.gameObject.SetActive(false); // ���ص�һ��Image
            imageToShow2.gameObject.SetActive(true); // ��ʾ�ڶ���Image
        }
    }
}
