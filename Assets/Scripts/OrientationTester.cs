using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OrientationTester : MonoBehaviour {
	public Text magnetometer;
	public Text accelerometer;
	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		accelerometer.text = Input.acceleration.ToString();
		magnetometer.text = "Wektor "+Input.compass.rawVector.ToString()+
			"kąt "+Input.compass.trueHeading.ToString()+
			" +- "+Input.compass.headingAccuracy.ToString();
		Vector3 acc = Input.acceleration;
		acc = new Vector3(-acc.x, acc.y,acc.z);
		transform.rotation =Quaternion.LookRotation(acc);

	}
}
