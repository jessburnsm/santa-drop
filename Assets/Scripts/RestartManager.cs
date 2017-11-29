using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour {
	public void RestartGame(){
		SceneManager.LoadScene("Main");
	}
}
