using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Vector3 Leftmove = new Vector3(1, 0, 0);
    public float moveSpeed = -10f;
    public float cameraLimit = -23;

    void Update()
    {
        this.gameObject.transform.position += Leftmove * moveSpeed * Time.deltaTime;
        if (this.gameObject.transform.position.x <= cameraLimit)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(transform.parent.gameObject,0.3f);
        }
    }
}
