using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("ThirdDayScene");
    }
}
