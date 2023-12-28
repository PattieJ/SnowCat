using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSnow : MonoBehaviour
{ 
    public GameObject[] snow;
    public int ArrowRotation;
    public int snowNum;
    private int a1 = -1;
    private int a2 = -2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Create");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Create()
    {
        while(true)
        {
            Vector3 position = new Vector3(
                Random.Range(-8f, 8f),
                Random.Range(-3f, 3f),
                0f
            );
            snowNum = Random.Range(0, 4);
            ArrowRotation = Random.Range(0, 4);
            while (ArrowRotation == a1 || ArrowRotation == a2)
            {
                ArrowRotation = Random.Range(0, 4);
            }
            a2 = a1;
            a1 = ArrowRotation;
            Vector3 rotation = new Vector3(
                0f,
                0f,
                90f * ArrowRotation
            );
            Quaternion Rotation = Quaternion.Euler(rotation);
            Instantiate(snow[snowNum], position, Rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
