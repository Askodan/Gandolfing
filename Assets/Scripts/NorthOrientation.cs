using UnityEngine;
using System.Collections;

public class NorthOrientation : MonoBehaviour {
	public float lerpSpeed;
	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation =Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0,Input.compass.trueHeading, 0),lerpSpeed*Time.deltaTime);;
	}
}
