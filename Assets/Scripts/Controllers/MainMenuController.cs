using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	[SerializeField]private Animator mainAnim, ballAnim;

	void Awake() {
		mainAnim = GameObject.Find ("Main Holder").GetComponent<Animator> ();
		ballAnim = GameObject.Find ("Balls Holder").GetComponent<Animator> ();
	}

	public void PlayGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Gameplay");
	}

	public void SelectBall() {
		mainAnim.Play ("FadeOut");
		ballAnim.Play ("FadeIn");
	}

	public void BackToMenu() {
		mainAnim.Play ("FadeIn");
		ballAnim.Play ("FadeOut");
	}


} // MainMenuController
























































