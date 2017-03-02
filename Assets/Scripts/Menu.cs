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
		quality = QualitySettings.names [0];
		QualitySettings.SetQualityLevel (0);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		if (GUI.Button(new Rect(0, 0, buttonWitdh, buttonHeight), "Test1. Basic mesh rendering")) {
			logContent = "";
			SceneManager.LoadScene ("Test01");
		}
		if (GUI.Button(new Rect(0, 40, buttonWitdh, buttonHeight), "Test2. Complex mesh rendering")) {
			logContent = "";
			SceneManager.LoadScene ("Test02");
		}
		if (GUI.Button(new Rect(0, 80, buttonWitdh, buttonHeight), "Test3. Lights & Shadows")) {
			logContent = "";
			SceneManager.LoadScene ("Test03");
		}
		if (GUI.Button(new Rect(0, 120, buttonWitdh, buttonHeight), "Test4. Textures")) {
			logContent = "";
			SceneManager.LoadScene ("Test04");
		}
		if (GUI.Button(new Rect(0, 160, buttonWitdh, buttonHeight), "Test5. Particle systems")) {
			logContent = "";
			SceneManager.LoadScene ("Test05");
		}

		if (GUI.Button(new Rect(Screen.width-buttonWitdh, 0, buttonWitdh, buttonHeight), "Quality: " + QualitySettings.names [0])) {
			quality = QualitySettings.names [0];
			QualitySettings.SetQualityLevel (0);
		}
		if (GUI.Button(new Rect(Screen.width-buttonWitdh, 40, buttonWitdh, buttonHeight), "Quality: " + QualitySettings.names [QualitySettings.names.Length-1])) {
			quality = QualitySettings.names [QualitySettings.names.Length-1];
			QualitySettings.SetQualityLevel (QualitySettings.names.Length-1);
		}
		if  (GUI.Button(new Rect(Screen.width-buttonWitdh, 120, buttonWitdh, buttonHeight), "Show Log")) {
			displayLog = !displayLog;
		}
		if  (GUI.Button(new Rect(Screen.width-buttonWitdh, 160, buttonWitdh, buttonHeight), "Quit")) {
			Application.Quit();
		}

		if (displayLog)
			GUI.TextArea(new Rect(10,10, Screen.width-20, Screen.height-20), logContent);
	}
}
