using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fish;
    public float spawnAreaX = 10f; // 生成小鱼的 X 范围
    public float spawnAreaY = 0f; // 生成小鱼的 Y 范围
    public int fishNum = 0;
    private float timer = 0f;
    private float RandomTime = 0.5f;
    private float minRandomTime = 0.1f;
    private float maxRandomTime = 3f;
    private float fish_x;
    private float fish_y;

    public GameObject shark;
    private float sharkTimer = 0f;
    private float sharkRandomTime = 3f;
    private float minSharkTime = 10f;
    private float maxSharkTime = 30f;

    public GameObject bird;
    private float birdTimer = 0f;
    private float birdRandomTime = 1f;
    private float minBirdTime = 10f;
    private float maxBirdTime = 30f;

    public GameObject penguin;
    private float penguinTimer = 0f;
    private float penguinRandomTime = 5f;
    private float minPenguinTime = 30f;
    private float maxPenguinTime = 50f;

    void Update()
    {
        timer += Time.deltaTime;
        sharkTimer += Time.deltaTime;
        birdTimer += Time.deltaTime;
        penguinTimer += Time.deltaTime;
        if(timer >= RandomTime)
        {
            timer = 0f;
            FishBorn();
            fishNum++;
        }
        if(sharkTimer >= sharkRandomTime)
        {
            sharkTimer = 0f;
            sharkBorn();
        }
        if(birdTimer >= birdRandomTime)
        {
            birdTimer = 0f;
            birdBorn();
        }
        if(penguinTimer >= penguinRandomTime)
        {
            penguinTimer = 0f;
            penguinBorn();
        }
    }

    private void FishBorn()
    {
        if (fish != null)
        {
            fish_x = Random.Range(spawnAreaX + 5, spawnAreaX +30);
            fish_y = Random.Range(spawnAreaY-10, spawnAreaY-3);
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(fish, fishPos, Quaternion.identity);
            RandomTime = Random.Range(minRandomTime, maxRandomTime);
        }
    }
    private void sharkBorn()
    {
        if (shark != null)
        {
            fish_x = Random.Range(spawnAreaX + 5, spawnAreaX + 30);
            fish_y = Random.Range(spawnAreaY - 10, spawnAreaY - 3);
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(shark, fishPos, Quaternion.identity);
            sharkRandomTime = Random.Range(minSharkTime, maxSharkTime);

        }
    }

    private void birdBorn()
    {
        if (bird != null)
        {
            fish_x = Random.Range(spawnAreaX - 35, spawnAreaX-25);
            fish_y = Random.Range(spawnAreaY, spawnAreaY+4);
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(bird, fishPos, Quaternion.identity);
            birdRandomTime = Random.Range(minBirdTime, maxBirdTime);

        }
    }

    private void penguinBorn()
    {
        if (penguin != null)
        {
            fish_x = Random.Range(spawnAreaX - 35, spawnAreaX - 25);
            fish_y = -16.8f;
            Vector3 fishPos = new Vector3(fish_x, fish_y, fish.transform.position.z);
            Instantiate(penguin, fishPos, Quaternion.identity);
            penguinRandomTime = Random.Range(minPenguinTime, maxPenguinTime);
        }
    }

    public int fish_count()
    {   
            return fishNum;
    }
}
