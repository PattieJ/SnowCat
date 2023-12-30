using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip getsnow;
    public AudioClip misssnow;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGetSnowClip()
    {
       // Debug.Log("1");
        AudioSource.PlayClipAtPoint(getsnow, transform.position);
    }
    public void PlayMissSnowClip()
    {
       // Debug.Log("2");
        AudioSource.PlayClipAtPoint(misssnow, transform.position);
    }
}
