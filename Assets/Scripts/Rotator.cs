using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private int speed = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + speed * Time.deltaTime, transform.localRotation.eulerAngles.z);
	}
}
