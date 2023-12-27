using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeSpin : MonoBehaviour
{
    public float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = Random.Range(10f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        // 
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
