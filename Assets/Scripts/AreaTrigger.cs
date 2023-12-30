using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour
{
    public Image imageToActivate;
    public Image imageNotActivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 假设进入触发器的是角色
        {
            Debug.Log("1");
            imageToActivate.gameObject.SetActive(true); // 激活Image
            imageNotActivate.gameObject.SetActive(false);
        }
    }
}
