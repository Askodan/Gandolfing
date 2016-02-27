using UnityEngine;
using System.Collections;

public class Orientation : MonoBehaviour {
	public float lerpSpeed;
	//public Transform simulation;
	void Start () {
		
	}

	void Update () {
		Vector3 acc = Input.acceleration;
		//acc = simulation.rotation.eulerAngles;
		acc = new Vector3 (acc.x, acc.y, -acc.z);
		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation (acc, -Vector3.forward),lerpSpeed*Time.deltaTime);
	}
}
/*
	public UnityEngine.UI.Text modenumber;
	int prevTouchcount=0;
	int mode=14;
	int modesNum=16;*/
/*	if (Input.touchCount != 0) {
prevTouchcount = Input.touchCount;
}
if (prevTouchcount != 0) {
	mode++;
	if (mode == modesNum) {
		mode = 0;
	}
	modenumber.text = mode.ToString ();
	prevTouchcount = 0;
}*/
/*	switch (mode) {
//code original
case 0:
acc = new Vector3 (-acc.x, acc.y, acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 1:
acc = new Vector3 (-acc.x, acc.y, acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 2:
acc = new Vector3 (-acc.x, -acc.y, acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 3:
acc = new Vector3 (-acc.x, -acc.y, acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 4:
acc = new Vector3 (acc.x, acc.y, acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 5:
acc = new Vector3 (acc.x, acc.y, acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 6:
acc = new Vector3 (acc.x, acc.y, -acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 7:
acc = new Vector3 (acc.x, acc.y, -acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 8:
acc = new Vector3 (-acc.x, acc.y, -acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 9:
acc = new Vector3 (-acc.x, acc.y, -acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 10:
acc = new Vector3 (acc.x, -acc.y, acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 11:
acc = new Vector3 (acc.x, -acc.y, acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 12:
acc = new Vector3 (acc.x, -acc.y, -acc.z);
if (inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 13:
acc = new Vector3 (acc.x, -acc.y, -acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
case 14:*/
/*case 15:
acc = new Vector3 (acc.x, acc.y, -acc.z);
if (!inverse)
	transform.rotation = Quaternion.Inverse (Quaternion.LookRotation (acc, -Vector3.forward));
else
	transform.rotation = Quaternion.LookRotation (acc, -Vector3.forward);
break;
}*/