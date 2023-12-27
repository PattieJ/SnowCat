using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyAnimalController : MonoBehaviour
{
    public Vector3 Leftmove = new Vector3(1, 0, 0);
    public float moveSpeed = 3f;
    public float cameraLimit = 30f;

    void Update()
    {
        this.gameObject.transform.position += Leftmove * moveSpeed * Time.deltaTime;
        if (this.gameObject.transform.position.x >= cameraLimit)
        {
            Destroy(transform.gameObject);
        }
    }
}
