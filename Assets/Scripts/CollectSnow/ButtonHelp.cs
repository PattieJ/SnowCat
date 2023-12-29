using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelp : MonoBehaviour
{
    private Help helper;
    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.FindWithTag("PauseController").GetComponent<Help>();
    }

    public void Click()
    {
        if (!helper.needHelp)
        {
            helper.closeHelp();
        }
        else
        {
            helper.showHelp();
        }
    }
}
