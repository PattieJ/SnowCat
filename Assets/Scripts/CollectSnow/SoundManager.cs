using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip getsnow;
    public static AudioClip misssnow;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        getsnow = Resources.Load<AudioClip>("Snow/GetSnow");
        misssnow = Resources.Load<AudioClip>("Snow/MissSnow");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayGetSnowClip()
    {
        audioSrc.PlayOneShot(getsnow);
    }
    public static void PlayMissSnowClip()
    {
        audioSrc.PlayOneShot(misssnow);
    }
}
