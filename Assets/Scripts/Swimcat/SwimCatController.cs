using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimCatController : MonoBehaviour
{
    public Vector2 swim = new Vector2(0,5);
    public float waterSurfaceY = 5.5f;
    public ParticleSystem bubblePS;
    public SwimCatHealth swimCatHealth;

    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] private float hitAmount = 2f;

    AudioSource audioSource;
    public AudioClip swimAudio;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < waterSurfaceY)
        {
            Swim();
        }
        if(transform.position.y > waterSurfaceY)
        {
            bubblePS.Stop();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge") && transform.position.y < waterSurfaceY)
        {
            Up();
        }

        if (collision.gameObject.CompareTag("shark"))
        {
            hit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            //Debug.Log("1");
            animator.SetBool("IsUp",false);
        }
        if (collision.gameObject.CompareTag("shark"))
        {
            animator.ResetTrigger("hit");
            swimCatHealth.hitHealth(hitAmount);
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
            swimCatHealth.hitHealth(hitAmount);
        }
    }
    private void Swim()
    {
        animator.SetBool("IsSwim", true);
        rb.velocity = swim;
        playBubble();
        audioSource.clip = swimAudio;
        audioSource.Play();
    }

    private void Up()
    {
        //Debug.Log("1");
        //animator.SetBool("IsSwim", false);
        animator.SetBool("IsUp", true);
    }

    private void hit()
    {
        animator.SetTrigger("hit");
    }

    private void playBubble()
    {
        bubblePS.Play();
    }


}
