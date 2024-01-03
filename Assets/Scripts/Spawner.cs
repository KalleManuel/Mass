using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectPool;

    public List <GameObject> objectsInScene;

    public float timer = 1;
    private float padding;

    private Camera gameCamera;
    public Vector3 spawnpoint;
    public Vector3 tempSpawnPos;

    private void Start()
    {
        gameCamera = Camera.main;

    }

    void Update()
    {
        if (timer > 0)
        {
            timer-= Time.deltaTime;
        }
        else
        {
            FindSpawnPoint();
            GameObject spawnedObject = Instantiate(objectPool[0], spawnpoint, Quaternion.identity);
            objectsInScene.Add(spawnedObject);
            timer = Random.Range(3, 5);
           
        }
    }

    public void FindSpawnPoint()
    {
       
        float dir = Random.Range(0, 5);
        float randomPos = Random.Range(0.0f, 1f);
        padding = Random.Range(5, 10);

        if (dir == 1)
        {
           
            tempSpawnPos = gameCamera.ViewportToWorldPoint(new Vector3(0, randomPos, 0));
            spawnpoint = new Vector3(tempSpawnPos.x - padding, tempSpawnPos.y, 0); 
        }
        else if (dir == 2)
        {
            tempSpawnPos = gameCamera.ViewportToWorldPoint(new Vector3(randomPos, 0, 0));
            spawnpoint = new Vector3(tempSpawnPos.x, tempSpawnPos.y - padding, 0);

        }

        else if (dir == 3)
        {
            tempSpawnPos = gameCamera.ViewportToWorldPoint(new Vector3(1, randomPos, 0));
            spawnpoint = new Vector3(tempSpawnPos.x + padding, tempSpawnPos.y, 0);

        }
        else if (dir == 4)
        {
            tempSpawnPos = gameCamera.ViewportToWorldPoint(new Vector3(randomPos, 1, 0));
            spawnpoint = new Vector3(tempSpawnPos.x, tempSpawnPos.y + padding, 0);

        }
        else
        {
            tempSpawnPos = gameCamera.ViewportToWorldPoint(new Vector3(0, randomPos, 0));
            spawnpoint = new Vector3(tempSpawnPos.x - padding, tempSpawnPos.y, 0);

        }

        // check if dot will collide with other dot before spawning it



       
    }
}
