using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    //public GameObject coinPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Find PlayerController-script from Player GameObject.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // Obstacles spawns on intervals
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //InvokeRepeating("SpawnCoin", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Spawns obstacles until gameOver == True
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
    
    /*void SpawnCoin()
    {
        // Spawns coins until gameOver == True
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
        }
    }
    */
}
