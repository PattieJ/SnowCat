using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSnow : MonoBehaviour
{ 
    public GameObject[] snow;
    public int ArrowRotation;
    public int snowNum;

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
