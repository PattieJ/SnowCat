using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MenuList;
    [SerializeField] private bool MenuFlag = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuList.SetActive(MenuFlag);
        }
        MenuActive();

    }
    void MenuActive()
    {
        if (MenuList.activeSelf == true)
        {
            Time.timeScale = (0);//stop
        }
        else
        {
            Time.timeScale = (1);//recover
        }
        MenuFlag = !MenuFlag;
    }
}
 
