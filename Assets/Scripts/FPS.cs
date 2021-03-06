﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FPS : MonoBehaviour {

	public static string info = "";

	protected float deltaTime = 0.0f;

	protected float lastFramesFPSSum = 0;
	protected float lastFramesFPSAvg = 0;
	protected int   lastFramesCount = 0;
	protected int   lastFramesMax = 100;

	public static bool newLogEntry = false;

	protected float elapsedTime = 0;
	protected float intervalSeconds = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= intervalSeconds) {
			newLogEntry = true;
			elapsedTime = 0;	
		}

		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	// Referencia: http://wiki.unity3d.com/index.php?title=FramesPerSecond
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 30;
		style.normal.textColor = new Color (0.0f, 1f, 1f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;

		lastFramesFPSSum = lastFramesFPSSum + fps;
		lastFramesCount++;
		if (lastFramesCount == lastFramesMax) {
			lastFramesFPSAvg = lastFramesFPSSum / (float)lastFramesMax;
			lastFramesCount = 0;
			lastFramesFPSSum = 0;
		}

		string text = string.Format ("{0:0.0} ms ({1:0} fps {2:0} avg ", msec, fps, lastFramesFPSAvg) + ("Fastest"==Menu.quality?"Lo":"Hi") + " qty) " + info;
		GUI.Label(rect, text, style);
		if (newLogEntry) {
			Menu.logContent = Menu.logContent + "\n" + text;
			newLogEntry = false;
		}

		if (GUI.Button(new Rect(w-200, h-80, 200, 80), "STOP")) {
			SceneManager.LoadScene ("Main");
		}
	}
}
