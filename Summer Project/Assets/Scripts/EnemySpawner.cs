using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3 spawnOffset;
    public GameObject spawnObject;
    public float yLocation;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnOffset = new Vector3(transform.position.x, yLocation, transform.position.z);
        InvokeRepeating("SpawnObject", 3f, spawnRate);
    }

    void SpawnObject()
    {
        Instantiate(spawnObject, spawnOffset, Quaternion.identity);
    }

}


