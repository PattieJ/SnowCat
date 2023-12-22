using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimcatSplash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject  splashAnim;
    public float edgePixel;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayAnimationAtCollision(collision.transform.position);
        }
    }

    void PlayAnimationAtCollision(Vector3 position)
    {
        if (splashAnim != null)
        {
            position.y = edgePixel;
            Instantiate(splashAnim, position, Quaternion.identity);
        }
    }

}
