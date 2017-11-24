using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://answers.unity.com/questions/669779/how-can-i-show-number-of-lives-as-hearts-or-other.html
public class LivesCounter : MonoBehaviour {

    public Texture texture;

    public LevelManager levelManager;

    private int lives;

    private float texWidth;
    private float texHeight;

	// Use this for initialization
	void Start () {
        texWidth = texture.width;
        texHeight = texture.height;

        lives = levelManager.lives;
    }

    // Update is called once per frame
    void Update()
    {
        lives = levelManager.lives;
    }

	void OnGUI () {
        if (lives > 0)
        {
            var posRect = new Rect(70, 30, texWidth / 5 * lives, texHeight);
            var texRect = new Rect(0, 0, 1.0f / 5 * lives, 1.0f);
            GUI.DrawTextureWithTexCoords(posRect, texture, texRect);
        }
    }
}