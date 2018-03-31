using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public Transform mainMenu, aboutSection;

	void Start() {
		StartCoroutine (JumpToScene ());
	}

	//Not used yet - Should be for loading scene after waiting for cutscene.
	IEnumerator JumpToScene() {
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene ("GameScene");
	}

	//Play button function to start game scene.
	public void LoadScene(string name) {
		Application.LoadLevel (name);
	}

	//Exit button function to quit game.
	public void QuitGame() {
		Application.Quit ();
	}

	//Function to switch between main menu and about section when 'About' is clicked.
	public void AboutSection(bool clicked){
		if (clicked == true){
			aboutSection.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			aboutSection.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}
}