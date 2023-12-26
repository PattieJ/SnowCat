using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimCatController : MonoBehaviour
{
    public Vector2 swim = new Vector2(0,5);
    public float waterSurfaceY = 5.5f;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSwim", true);
            rb.velocity = swim;
        }
        else
        {
            animator.SetBool("IsSwim", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge") && transform.position.y < waterSurfaceY)
        {
            //Debug.Log("1");
            animator.SetBool("IsSwim", false);
            animator.SetBool("IsUp", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            //Debug.Log("1");
            animator.SetBool("IsUp",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            hit();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            animator.ResetTrigger("hit");
        }
    }

    private void hit()
    {
        animator.SetTrigger("hit");
    }
}
