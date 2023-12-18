using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimCatController : MonoBehaviour
{
    public Vector2 swim = new Vector2(0,4);
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
        PlayerAnim();
    }


    private void PlayerAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsUp", true);
            rb.velocity = swim;
        }
        else
        {
            animator.SetBool("IsUp", false);
        }
    }
}
