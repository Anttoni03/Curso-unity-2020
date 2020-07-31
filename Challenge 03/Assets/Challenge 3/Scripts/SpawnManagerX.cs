using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 1;
    private float spawnInterval = 0.8f;

    public float upperBound, lowerBound;

    private Vector3 spawnLocation;

    private PlayerControllerX playerControllerScript;

    private int index;
    private float randomY;

    
    //====================================================================================================================
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = this.transform.position;
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    
    //====================================================================================================================
    
    
    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        index = Random.Range(0, objectPrefabs.Length);
        randomY = Random.Range(lowerBound, upperBound);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], new Vector3(spawnLocation.x, randomY, spawnLocation.z), objectPrefabs[index].transform.rotation);
        }
    }
}
