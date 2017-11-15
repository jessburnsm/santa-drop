using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
		if (rb != null) {
			Debug.Log ("Game Ends");
			Application.LoadLevel("GameOver");
		}
	}
}
