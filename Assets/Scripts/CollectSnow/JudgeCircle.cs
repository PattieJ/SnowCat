using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCircle : MonoBehaviour
{
    public Material circleEdgeMaterial;
    float rate;
    void Start()
    {
        rate = circleEdgeMaterial.GetFloat("_CircleEdge");
        rate *= transform.localScale.x;
    }

    void Update()
    {
        circleEdgeMaterial.SetFloat("_CircleEdge", rate / transform.localScale.x);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f, transform.localScale.z);
        }
    }
}