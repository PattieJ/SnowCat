using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimcatBgController : MonoBehaviour
{
    public Vector3 Leftmove = new Vector3(1, 0, 0);
    public float moveSpeed;
    private float width = 67.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Leftmove * moveSpeed * Time.deltaTime;
        if (this.gameObject.transform.position.x <= -width)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 2 * width, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
