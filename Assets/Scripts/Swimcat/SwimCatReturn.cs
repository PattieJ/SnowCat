using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwimCatReturn : MonoBehaviour
{
    public void returnScene()
    {
        SceneManager.LoadScene(2);
    }
}
