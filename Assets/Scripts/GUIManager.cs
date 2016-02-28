using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	[SerializeField] GameObject debug;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (debug.activeSelf) {
				debug.SetActive (false);
			} else {
				debug.SetActive (true);
			}
		}
	}
	public void Exit(){
		Application.Quit ();
	}
}
