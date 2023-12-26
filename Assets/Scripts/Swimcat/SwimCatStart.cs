using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimCatStart : MonoBehaviour
{
    public GameObject startMenu;

    void Start()
    {
        Time.timeScale = (0);//stop
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startMenu.SetActive(false);
            Time.timeScale = (1);//recover
        }
    }
}
