using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector3 spawnLocation;
    public GameObject spawnObject;
    public float yLocation;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = new Vector3(transform.position.x, yLocation, transform.position.z);
        //SpawnObject();
        //InvokeRepeating("SpawnObject", 3f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        Instantiate(spawnObject, spawnLocation, Quaternion.identity);
    }

}


