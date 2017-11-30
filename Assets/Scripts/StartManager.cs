using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {
	public Animator instructionMenuAnimator;
	public Animator mainMenuAnimator;
	public Animator difficultyMenuAnimator;

	void Start(){
		Screen.SetResolution (512, 640, false);
	}

	public void OpenInstructions(){
		instructionMenuAnimator.SetBool("isOpen", true);
	}

	public void CloseInstructions(){
		instructionMenuAnimator.SetBool("isOpen", false);
	}

	public void OpenDifficulty(){
		mainMenuAnimator.SetBool("isOpen", false);
		difficultyMenuAnimator.SetBool("isOpen", true);
	}

	public void StartGame(){
		SceneManager.LoadScene("Scene01");
	}
}
