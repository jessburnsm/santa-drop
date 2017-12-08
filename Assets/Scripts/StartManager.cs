using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {
	public Animator instructionMenuAnimator;
	public Animator mainMenuAnimator;
	public Animator difficultyMenuAnimator;
	public Animator santaSelectMenuAnimator;
	public SpriteRenderer santaSprite;
	public Text spriteDescription;
	public SantaOptions[] santaOptions;

	void Start(){
		Screen.SetResolution (512, 640, false);

		santaSprite.sprite = santaOptions[ApplicationModel.SantaSprite].sprite;
		spriteDescription.text = santaOptions[ApplicationModel.SantaSprite].description;
	}

	public void OpenInstructions(){
		instructionMenuAnimator.SetBool("isOpen", true);
	}

	public void CloseInstructions(){
		instructionMenuAnimator.SetBool("isOpen", false);
	}

	public void OpenSantaSelect(){
		mainMenuAnimator.SetBool("isOpen", false);
		santaSelectMenuAnimator.SetBool("isOpen", true);
	}

	public void CloseSantaSelect(){
		mainMenuAnimator.SetBool("isOpen", true);
		santaSelectMenuAnimator.SetBool("isOpen", false);
	}

	public void OpenDifficulty(){
		mainMenuAnimator.SetBool("isOpen", false);
		difficultyMenuAnimator.SetBool("isOpen", true);
	}

	public void StartGameEasy(){
		SceneManager.LoadScene("Easy");
	}

	public void StartGameMedium(){
		SceneManager.LoadScene("Medium");
	}

	public void StartGameHard(){
		SceneManager.LoadScene("Hard");
	}

	public void SwapSanta(){
		ApplicationModel.SantaSprite++;

		if (ApplicationModel.SantaSprite > santaOptions.Length - 1)
			ApplicationModel.SantaSprite = 0;

		santaSprite.sprite = santaOptions[ApplicationModel.SantaSprite].sprite;
		spriteDescription.text = santaOptions[ApplicationModel.SantaSprite].description;
	}
}
