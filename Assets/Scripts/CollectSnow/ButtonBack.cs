using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    private PauseGame ifPause;
    void Start()
    {
        ifPause = GameObject.FindWithTag("PauseController").GetComponent<PauseGame>();
    }
    public void Click()
    {
        if (!ifPause.GameIsPause)
        {
            ifPause.Pause();
        }
        else
        {
            ifPause.Resume();
        }
    }
}
