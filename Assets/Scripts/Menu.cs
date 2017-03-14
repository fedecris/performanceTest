using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public static string quality = "Not set";

	public static string logContent = "";

	protected static int buttonWitdh = Screen.width / 2 - 10;
	protected static int buttonHeight = 40;
	protected static bool displayLog = false;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		quality = QualitySettings.names [0];
		QualitySettings.SetQualityLevel (0);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		// Test Set
		if (!displayLog) {
			if (GUI.Button (new Rect (0, 0, buttonWitdh, buttonHeight), "Test1. Basic mesh rendering")) {
				loadLevel ("Test01");
			}
			if (GUI.Button (new Rect (0, 40, buttonWitdh, buttonHeight), "Test2. Complex mesh rendering")) {
				loadLevel ("Test02");
			}
			if (GUI.Button (new Rect (0, 80, buttonWitdh, buttonHeight), "Test3. Lights & Shadows")) {
				loadLevel ("Test03");
			}
			if (GUI.Button (new Rect (Screen.width - buttonWitdh, 0, buttonWitdh, buttonHeight), "Test4. Textures")) {
				loadLevel ("Test04");
			}
			if (GUI.Button (new Rect (Screen.width - buttonWitdh, 40, buttonWitdh, buttonHeight), "Test5. Particle systems")) {
				loadLevel ("Test05");
			}
			if (GUI.Button (new Rect (Screen.width - buttonWitdh, 80, buttonWitdh, buttonHeight), "Test6. Physics")) {
				loadLevel ("Test06");
			}

			// Calidad de render
			if (GUI.Button(new Rect(0, Screen.height-buttonHeight*2, buttonWitdh, buttonHeight), "Quality: " + QualitySettings.names [0])) {
				quality = QualitySettings.names [0];
				QualitySettings.SetQualityLevel (0);
			}
			if (GUI.Button(new Rect(Screen.width-buttonWitdh, Screen.height-buttonHeight*2, buttonWitdh, buttonHeight), "Quality: " + QualitySettings.names [QualitySettings.names.Length-1])) {
				quality = QualitySettings.names [QualitySettings.names.Length-1];
				QualitySettings.SetQualityLevel (QualitySettings.names.Length-1);
			}
		}


		if  (GUI.Button(new Rect(0, Screen.height-buttonHeight, buttonWitdh, buttonHeight), "Show Log")) {
			displayLog = !displayLog;
		}
		if  (GUI.Button(new Rect(Screen.width-buttonWitdh, Screen.height-buttonHeight, buttonWitdh, buttonHeight), "Quit")) {
			Application.Quit();
		}

		if (displayLog)
			GUI.TextArea(new Rect(0,0, Screen.width, Screen.height-buttonHeight), logContent);
	}


	/** Carga de un nivel reiniciando valores */
	protected void loadLevel(string levelName) {
		FPS.info = "";
		logContent = "";
		SceneManager.LoadScene (levelName);
	}
}
