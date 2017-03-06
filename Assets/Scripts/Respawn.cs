using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -100) {
			transform.position = new Vector3 (Random.Range(-20f, 20f), Random.Range(30, 50), Random.Range(-20f, 20f));
		}
	}
}
