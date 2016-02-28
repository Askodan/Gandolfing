using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FunsManager : MonoBehaviour {
	[SerializeField] HeritageManager heritageManager;
	[SerializeField] Text text;
	[SerializeField] GameObject cloud;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < heritageManager.WarsawHeritage.Length; i++) {
			heritageManager.WarsawHeritage [i].fun = GameObject.Instantiate (heritageManager.WarsawHeritage [i].fun);
			heritageManager.WarsawHeritage [i].fun.SetActive (false);
			heritageManager.WarsawHeritage [i].fun.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0){
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				if (hit.transform.gameObject == heritageManager.WarsawHeritage [heritageManager.activeOne].fun) {
					heritageManager.WarsawHeritage [heritageManager.activeOne].visited = true;
					StartCoroutine(SaySomething(heritageManager.WarsawHeritage[heritageManager.activeOne].info, 10f));
				}
			}
		}
	}
	IEnumerator SaySomething(string something, float time){
		cloud.SetActive (true);
		text.text = something;
		yield return new WaitForSeconds (time);
		cloud.SetActive (false);
	}
}
