using UnityEngine;

public class LevelEnd : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        // If player has hit an obstacle, end the game
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Level has ended.");
        }
    }
}
