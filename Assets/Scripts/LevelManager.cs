using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Level end menu
	public Animator levelEndMenu;
	public Text presentText;
	public Text chimneyText;
	public Text finalText;

	// Game over menu
	public Animator gameOverMenu;

	// Score counter
	private int score = 0;
	private int bonus = 10;
	public Text scoreText;

	// Level Generator
	public LevelGenerator levelGenerator;

    // Game lives
    public int lives = 3;
	
	// Update is called once per frame
	void Update() 
	{
		updateScoreText();
	}

	void updateScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	public void updateScore(){
		score += 1;
		updateScoreText();
	}

	public void endGame(){
		gameOverMenu.SetBool("isOpen", true);
	}

	public void endLevel(bool bonusApplied = false){
		presentText.text = "Presents: " + score + "/" + levelGenerator.numberOfCollectibles;

		int finalScore = score;
		if (bonusApplied) {
			finalScore += bonus;
			chimneyText.text = "Chimney Bonus: " + bonus + "/" + bonus;
		} else {
			chimneyText.text = "Chimney Bonus: 0/" + bonus;
		}

		finalText.text = "Final Score: " + finalScore;


		levelEndMenu.SetBool("isOpen", true);
	}

    public bool hitObstacle(){
        lives -= 1;

		if (lives <= 0) {
			endGame();
			return false;
		}
		return true;
    }

	public void restartGame(){
		SceneManager.LoadScene("Main");
	}

	public void restartLevel(){
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
}
