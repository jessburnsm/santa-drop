using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;
    public Transform LevelEnd;
	public Transform Chimney;

    private float minY;

    public int numberOfPlatforms = 200;
    public float levelWidth = 4f;
    public float obstacleMinY = .2f;
    public float obstacleMaxY = 1.5f;

    public int numberOfCollectibles = 50;
    public float collectibleMinY = 1.5f;
    public float collectibleMaxY = 3f;

    // Use this for initialization
    void Start () 
	{
        Vector3 spawnPosition = new Vector3();

		for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y -= Random.Range(obstacleMinY, obstacleMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }

        minY = spawnPosition.y;

        spawnPosition = new Vector3();

        for (int x = 0; x < numberOfCollectibles; x++)
        {
            spawnPosition.y -= Random.Range(collectibleMinY, collectibleMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        }

        // Find the lowest y value of an item in the game
        minY = minY < spawnPosition.y ? minY : spawnPosition.y;

		// Set the level end position and randomly position the chimney on top of it
        LevelEnd.position = new Vector2(0, minY - 5f);
		Chimney.position = new Vector2 (Random.Range (-.85f, 3.2f), Chimney.position.y);
    }

    public float getMinY()
    {
        return minY;
    }
}
