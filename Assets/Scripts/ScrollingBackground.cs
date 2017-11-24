using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	private Vector3 size;
	private Vector3 center;
	private SpriteRenderer c;
	private bool hasDrawnNextPanel = false;

	public Camera camera;
	public GameObject backgroundPrefab;

	void Start () {
		c = GetComponent<SpriteRenderer> ();
		center = c.bounds.center;
		size = c.bounds.size;
	}

	void FixedUpdate () {
		// If the camera is more than halfway down the background, we need to draw the next panel
		// Also make sure we haven't already drawn the panel
		if (!hasDrawnNextPanel && camera.transform.position.y < center.y) {
			Vector3 spawnPosition = new Vector3(0, center.y - size.y, 0);
			Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
			hasDrawnNextPanel = true;
		}

		// If the camera has left the background entirely, destroy this panel
        // Add a buffer of 2x to the size to make sure the background is still around if the player jumps
		if (hasDrawnNextPanel && camera.transform.position.y < (center.y - 1.5*size.y)) {
			Destroy (gameObject);
		}
	}
}
