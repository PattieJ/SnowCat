using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MenuList;
    [SerializeField] private bool MenuFlag = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuList.SetActive(MenuFlag);
            MenuFlag = !MenuFlag;
        }
        if(MenuFlag == false)
        {
            Time.timeScale = (0);//stop
        }
        else
        {
            Time.timeScale = (1);//recover
        }
    }
}
