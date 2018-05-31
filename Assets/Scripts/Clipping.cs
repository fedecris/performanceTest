using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Clipping : MonoBehaviour {


	/** Objeto a utilizar */
	public Camera cam;

	/** Segundos antes de incrementar */
	public float intervalSeconds = 20;
	/** Incremento.   */
	public int increment = 100;
	/** Limite de objetos a crear */
	public int maxClipping = 1500;

	/** Numero de clipping actual */
	protected int currentClipping = 100; 
	/** Tiempo desde ultimo incremento */
	protected float elapsedTime = 0;

	/** Objeto a utilizar */
	public Transform objeto;


	// Use this for initialization
	void Start () {
		// El clipping plane ya no tiene validez para estos tests
		cam.farClipPlane = Menu.totalSpawn * 10;
		// La posicion del objeto complejo se determina medianta el campo 
		// utilizado en los otros tests para especificar el numero de objetos
		objeto.position = new Vector3 (0, 0, Menu.totalSpawn);
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

			FPS.info = "Length: " + objeto.position.z;
			Debug.Log ("Length: " + objeto.position.z);
		}
	}
}
