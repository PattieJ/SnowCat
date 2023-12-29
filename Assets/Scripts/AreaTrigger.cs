using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour
{
    public Image imageToActivate;
    public Image imageNotActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // ������봥�������ǽ�ɫ
        {
            Debug.Log("1");
            imageToActivate.gameObject.SetActive(true); // ����Image
            imageToActivate.gameObject.SetActive(false);
        }
    }
}
