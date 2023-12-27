using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeSnow : MonoBehaviour
{
    public int snowScore;
    public GameObject GetScore;
    private float rotationZ;
    // Start is called before the first frame update
    void Start()
    {
        //rotationZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)) && rotationZ == 0f)
        //{
        //    GetSnow();
        //}
        //else if((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && rotationZ == 90f)
        //{
        //    GetSnow();
        //}
        //else if((Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow)) && rotationZ == 180f)
        //{
        //    GetSnow();
        //}
        //else if((Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)) && rotationZ == 270f)
        //{
        //    GetSnow();
        //}
    }

    private void GetSnow()
    {
        //Instantiate(GetScore, transform.position, transform.rotation);
        //Destroy(gameObject);
    }
}
