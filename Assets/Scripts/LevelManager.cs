using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Score counter
	private int score = 0;
	private int bonus = 10;
	private bool bonusApplied = false;
	public Text scoreText;

    // Game lives
    public int lives = 3;
	
	// Update is called once per frame
	void Update () {
		updateScoreText ();
	}

	void updateScoreText()
	{
		scoreText.text = "Score: "+ score;
	}

	public void addBonus(){
		score += bonus;
		bonusApplied = true;
		updateScoreText ();
	}

	public void updateScore(){
		score += 1;
		updateScoreText ();
	}

	public void endGame(){
		Debug.Log ("Game has ended!");
        SceneManager.LoadScene("GameOver");
	}

	public void endLevel(){
		Debug.Log ("Level has ended!");
	}

    public void hitObstacle(){
        lives -= 1;

        if (lives <= 0)
            endGame();
    }
}
