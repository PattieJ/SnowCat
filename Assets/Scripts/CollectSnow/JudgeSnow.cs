using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeSnow : MonoBehaviour
{
    public int snowScore;
    public GameObject GetScore;
    public GameObject SnowMiss;
    public GameObject JudgeCircle;
    public float scaleSpeed = 1.5f;

    private float rotationZ;
    private float gradeLevel;
    private CollectGame collectSnow;
    private GameObject Circle;
    // Start is called before the first frame update
    void Start()
    {
        rotationZ = transform.eulerAngles.z;
        collectSnow = GameObject.FindWithTag("GameController").GetComponent<CollectGame>();

        Circle = Instantiate(JudgeCircle, transform.position- new Vector3(0f,0f,2f), transform.rotation);
        Circle.transform.localScale *= 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectSnow.isGameOver) return;
        Circle.transform.localScale = new Vector3(
            Circle.transform.localScale.x - scaleSpeed*Time.deltaTime,
            Circle.transform.localScale.y - scaleSpeed*Time.deltaTime,
            Circle.transform.localScale.z
        );
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && rotationZ == 0f)
        {
            GetSnow();
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rotationZ == 90f)
        {
            GetSnow();
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && rotationZ == 180f)
        {
            GetSnow();
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && rotationZ == 270f)
        {
            GetSnow();
        }
        if(Circle.transform.localScale.x < 0.5f)
        {
            MissSnow();
        }
    }

    private void GetSnow()
    {
        if(Circle.transform.localScale.x > 2.5f)
        {
            MissSnow();
            return;
        }
        Instantiate(GetScore, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(Circle);
        if (Mathf.Abs(Circle.transform.localScale.x-1f)<= 0.1f)
        {
            collectSnow.GetScoreLevel("PERFECT");
            gradeLevel = 1f;
        }
        else if(Mathf.Abs(Circle.transform.localScale.x - 1f) <= 0.3f)
        {
            collectSnow.GetScoreLevel("GREAT");
            gradeLevel = 0.8f;
        }
        else
        {
            collectSnow.GetScoreLevel("COMMON");
            gradeLevel = 0.5f;
        }
        SoundManager.PlayGetSnowClip();
        collectSnow.AddScore((int)(snowScore *gradeLevel));
        collectSnow.CountScoreAll(snowScore);
    }

    private void MissSnow()
    {
        collectSnow.hurt();
        collectSnow.GetScoreLevel("MISS");
        Destroy(Circle);
        Destroy(gameObject);
        Instantiate(SnowMiss, transform.position, transform.rotation);
        SoundManager.PlayMissSnowClip();
        collectSnow.CountScoreAll(snowScore);


    }
}
