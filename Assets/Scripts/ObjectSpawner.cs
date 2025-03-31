using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public float limitX;
    public float limitY;

    public float spawnMin;
    public float spawnMax;

    public float despawnTime = 20;

    float lastSpawn;
    void Update()
    {
        if(lastSpawn < Time.time)
        {
            lastSpawn = Time.time + Random.Range(spawnMin, spawnMax);
            Vector3 spawnPos = transform.position;
            spawnPos.x += Random.Range(-limitX, limitX);
            spawnPos.y += Random.Range(-limitY, limitY);

            GameObject temp = Instantiate(objects[Random.Range(0, objects.Length)], spawnPos, Quaternion.Euler(0,0,0));
            Destroy(temp, despawnTime);
        }
    }
}
