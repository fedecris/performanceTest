using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public static string quality = "Not set";

	// Use this for initialization
	void Start () {
		quality = QualitySettings.names [0];
		QualitySettings.SetQualityLevel (0);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		if (GUI.Button(new Rect(0, 0, 300, 40), "Test1. Basic mesh rendering")) {
			SceneManager.LoadScene ("Test01");
		}
		if (GUI.Button(new Rect(0, 40, 300, 40), "Test2. Complex mesh rendering")) {
			SceneManager.LoadScene ("Test02");
		}
		if (GUI.Button(new Rect(0, 80, 300, 40), "Test3. Lights & Shadows")) {
			SceneManager.LoadScene ("Test03");
		}
		if (GUI.Button(new Rect(0, 120, 300, 40), "Test4. Textures")) {
			SceneManager.LoadScene ("Test04");
		}
		if (GUI.Button(new Rect(0, 160, 300, 40), "Test5. Particle systems")) {
			SceneManager.LoadScene ("Test05");
		}

		if (GUI.Button(new Rect(Screen.width-300, 0, 300, 40), "Quality: " + QualitySettings.names [0])) {
			quality = QualitySettings.names [0];
			QualitySettings.SetQualityLevel (0);
		}
		if (GUI.Button(new Rect(Screen.width-300, 40, 300, 40), "Quality: " + QualitySettings.names [QualitySettings.names.Length-1])) {
			quality = QualitySettings.names [QualitySettings.names.Length-1];
			QualitySettings.SetQualityLevel (QualitySettings.names.Length-1);
		}
		if  (GUI.Button(new Rect(Screen.width-300, 120, 300, 40), "Quit")) {
			Application.Quit();
		}


	}
}
