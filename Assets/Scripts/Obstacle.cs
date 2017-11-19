using UnityEngine;

public class Obstacle : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        // If player has hit an obstacle, end the game
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game is over.");
        }
    }
}
