using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public bool needHelp;
    private PauseGame ifPause;
    public GameObject helpMask;

    // Start is called before the first frame update
    void Start()
    {
        ifPause = GameObject.FindWithTag("PauseController").GetComponent<PauseGame>();
        ifPause.Pause();
        helpMask.SetActive(true);
        needHelp = true;
        showHelp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!needHelp)
            {
                closeHelp();
            }
            else
            {
                showHelp();
            }
        }
    }
    public void showHelp()
    {
        helpMask.SetActive(true);
        ifPause.Pause();
        needHelp = false;
    }
    public void closeHelp()
    {
        helpMask.SetActive(false);
        ifPause.Resume();
        needHelp = true;


    }
}
