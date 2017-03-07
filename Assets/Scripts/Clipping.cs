using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Clipping : MonoBehaviour {


	/** Objeto a utilizar */
	public Camera cam;

	/** Segundos antes de incrementar */
	protected float intervalSeconds = 10;
	/** Incremento.   */
	protected int increment = 100;
	/** Limite de objetos a crear */
	protected int maxClipping = 1500;

	/** Numero de clipping actual */
	protected int currentClipping = 100; 
	/** Tiempo desde ultimo incremento */
	protected float elapsedTime = 0;



	// Use this for initialization
	void Start () {
		cam.farClipPlane = currentClipping;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentClipping >= maxClipping)
			return;
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= intervalSeconds) {
			elapsedTime = 0;
			currentClipping = currentClipping + increment;
			cam.farClipPlane = currentClipping;

			FPS.info = "Length: " + currentClipping;
			Debug.Log ("Length: " + currentClipping);
		}
	}
}
