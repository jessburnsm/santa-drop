using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;
    public Transform LevelEnd;

    public int numberOfPlatforms = 200;
    public float levelWidth = 4.5f;
    public float obstacleMinY = .2f;
    public float obstacleMaxY = 1.5f;

    public int numberOfCollectibles = 50;
    public float collectibleMinY = 1.5f;
    public float collectibleMaxY = 3f;

    // Use this for initialization
    void Start () {
        Vector3 spawnPosition = new Vector3();

		for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y -= Random.Range(obstacleMinY, obstacleMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }

        float miny = spawnPosition.y;

        spawnPosition = new Vector3();

        for (int x = 0; x < numberOfCollectibles; x++)
        {
            spawnPosition.y -= Random.Range(collectibleMinY, collectibleMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        }

        // Find the lowest y value of an item in the game
        miny = miny < spawnPosition.y ? miny : spawnPosition.y;

        LevelEnd.position = new Vector2(0, miny - 5f); 
    }
}
