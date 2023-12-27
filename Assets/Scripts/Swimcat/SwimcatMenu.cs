using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwimcatMenu : MonoBehaviour
{
    public GameObject MenuList;
    [SerializeField] private bool MenuFlag = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeMenuList();
        }
    }

    public void activeMenuList()
    {
        MenuList.SetActive(MenuFlag);
        MenuFlag = !MenuFlag;
        if (MenuFlag == false)
        {
            Time.timeScale = (0);//stop
        }
        else
        {
            Time.timeScale = (1);//recover
        }
    }

   public void continueButton()
    {
        MenuList.SetActive(false);
        Time.timeScale = (1);
    }

    public void quitButton()
    {
        SceneManager.LoadScene(0);
    }
}
