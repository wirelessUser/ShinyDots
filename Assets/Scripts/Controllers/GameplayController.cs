using UnityEngine;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public void BackToMainMenu() {
		Application.LoadLevel ("MainMenu");
	}

}
