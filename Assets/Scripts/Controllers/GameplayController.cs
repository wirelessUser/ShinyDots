using UnityEngine;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public void BackToMainMenu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

}
