using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;



    private float moveX, moveY;//获取输入

    private Vector2 moveDirect;//移动方向

    private Animator animator;
    private Rigidbody2D rb;
    AudioSource audioSource;
    public AudioClip walkAudio;

    /* initialization
     * 1. animator
     * 2. rigidbody
     */
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
    /* 
     * 物理部分的update
     */
    void FixedUpdate()
    {
        Movement();
        PlayerAnim();
    }

    private void getInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
        Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
        Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            audioSource.clip = walkAudio;
            audioSource.Play();
        }
        moveX = Input.GetAxisRaw("Horizontal");//左右
        moveY = Input.GetAxisRaw("Vertical");//上下
        moveDirect = new Vector2(moveX, moveY);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveDirect.x * moveSpeed, moveDirect.y * moveSpeed);
    }

    private void PlayerAnim()
    {
        if(moveDirect != Vector2.zero)
        {
            animator.SetBool("IsWalking",true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        animator.SetFloat("velocityX", moveX);
        animator.SetFloat("velocityY", moveY);
    }
}
