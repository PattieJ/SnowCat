using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitNo : MonoBehaviour
{
    private PauseGame ifPause;
    void Start()
    {
        ifPause = GameObject.FindWithTag("PauseController").GetComponent<PauseGame>();
    }
    public void Click()
    {
        
        ifPause.Resume();
        
    }
}
