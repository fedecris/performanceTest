using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Factory : MonoBehaviour {

	public float randomRangeX = 1;
	public float randomRangeY = 1;
	public float randomRangeZ = 1;

	public bool isLight = false;

	/** Objeto a utilizar */
	public Transform objeto;

	/** Segundos antes de incrementar */
	protected float intervalSeconds = 10;
	/** Factor de crecimiento.  Por ejemplo Si es 2, se van duplicando (1, 2, 4, 8...). Si es 10 crece un orden de magnitud cada vez, etc. (1, 10, 100, 1000...) */
	public int incrementFactor = 2;
	/** Limite de objetos a crear */
	protected int maxObjects = 10000;

	/** Numero de instancias actual */
	protected int instanceQty = 0; 
	/** Tiempo desde ultimo incremento */
	protected float elapsedTime = 0;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (instanceQty > maxObjects)
			SceneManager.LoadScene ("Main");
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= intervalSeconds) {
			int oldQty = instanceQty;
			if (instanceQty == 0)
				instanceQty = 1;
			instanceQty = instanceQty * incrementFactor;
			if (incrementFactor == 1)
				instanceQty++;
			for (int i = 1; i <= instanceQty - oldQty; i++) {
				Object anObject = Instantiate (objeto, new Vector3 (Random.Range(-1f * randomRangeX, 1f * randomRangeX), Random.Range(-1f * randomRangeY, 1f * randomRangeY), Random.Range(-1f * randomRangeZ, 1f * randomRangeZ)), Quaternion.identity);
				if (isLight) {
					((Light)(((Transform)anObject).GetComponentInChildren<Light>())).color  = new Color (Random.Range (0, 255), Random.Range (0, 255), Random.Range (0, 255));
					((Light)(((Transform)anObject).GetComponentInChildren<Light> ())).intensity = .001f;
				}
			}
			elapsedTime = 0;	
			FPS.info = "Qty: " + instanceQty;
			Debug.Log ("Qty: " + instanceQty);
		}
	}


}
