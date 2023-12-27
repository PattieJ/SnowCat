using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fish;
    public float spawnAreaX = 10f; // 生成小鱼的 X 范围
    public float spawnAreaY = 0f; // 生成小鱼的 Y 范围
    private float timer = 0f;
    private float RandomTime = 0.5f;
    private float minRandomTime = 0.1f;
    private float maxRandomTime = 3f;
    private float fish_x;
    private float fish_y;
    public int fishNum = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= RandomTime)
        {
            timer = 0f;
            FishBorn();
            fishNum++;
            
        }
    }

    private void FishBorn()
    {
        if (fish != null)
        {
            fish_x = Random.Range(spawnAreaX, spawnAreaX +30);
            fish_y = Random.Range(spawnAreaY-8, spawnAreaY);
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(fish, fishPos, Quaternion.identity);

            RandomTime = Random.Range(minRandomTime, maxRandomTime);
        }
    }

    public int fish_count()
    {   
            return fishNum;
    }
}
