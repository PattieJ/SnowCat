using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwimCatScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    public AudioClip magicAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            AudioSource.PlayClipAtPoint(magicAudio, transform.position);
            addScore();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(collision.gameObject.transform.parent.gameObject, 0.3f);
        }
    }
    private void addScore()
    {
        score=score+2;
        scoreText.text = "score:" + score;
        //Debug.Log("score:" + score);
    }
}
