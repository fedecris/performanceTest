using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Factory : MonoBehaviour {

	/** Objeto a utilizar */
	public Transform objeto;

	/** Segundos antes de incrementar */
	protected float intervalSeconds = 10;
	/** Factor de crecimiento.  Por ejemplo Si es 2, se van duplicando (1, 2, 4, 8...). Si es 10 crece un orden de magnitud cada vez, etc. (1, 10, 100, 1000...) */
	public int incrementFactor = 2;
	/** Limite de objetos a crear */
	protected int maxObjects = 2000;

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
				Instantiate (objeto, new Vector3 (0, 0, 0), Quaternion.identity);
			}
			elapsedTime = 0;	
			FPS.info = "Qty: " + instanceQty;
			Debug.Log ("Qty: " + instanceQty);
		}
	}


}
