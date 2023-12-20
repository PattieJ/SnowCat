using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fish;
    public float spawnAreaX = 5f; // 生成小鱼的 X 范围
    public float spawnAreaY = 5f; // 生成小鱼的 Y 范围
    private float timer = 0f;
    private float RandomTime = 1f;
    private float minRandomTime = 1f;
    private float maxRandomTime = 5f;
    private float fish_x;
    private float fish_y;

    void Start()
    {
        FishBorn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= RandomTime)
        {
            timer = 0f;
            FishBorn();
        }
    }

    private void FishBorn()
    {
        if (fish != null)
        {
            fish_x = Random.Range(spawnAreaX-10, spawnAreaX);
            fish_y = Random.Range(spawnAreaY-8, spawnAreaY);
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(fish, fishPos, Quaternion.identity);

            RandomTime = Random.Range(minRandomTime, maxRandomTime);
        }
    }
}
