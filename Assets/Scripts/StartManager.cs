using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {
	public Animator animator;

	void Start(){
		Screen.SetResolution (512, 640, false);
	}

	public void OpenInstructions(){
		animator.SetBool("isOpen", true);
	}

	public void CloseInstructions(){
		animator.SetBool("isOpen", false);
	}

	public void StartGame(){
		SceneManager.LoadScene("Scene01");
	}
}
