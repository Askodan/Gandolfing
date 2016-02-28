using UnityEngine;
using System.Collections;

public class GetCameraView : MonoBehaviour {
	WebCamTexture tex;
	// Use this for initialization
	void Start () {
		WebCamDevice[] WBD = WebCamTexture.devices;
		tex = new WebCamTexture ();
		Material mat = new Material (GetComponent<MeshRenderer> ().material);
		//mat.SetTexture (0, tex);
		mat.mainTexture = tex;
		GetComponent<MeshRenderer> ().material=mat;
		tex.deviceName = WBD [0].name;
		tex.Play ();



	}
	
	// Update is called once per frame
	void Update () {
	}
}
