using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FunPlacer : MonoBehaviour {
	[SerializeField] HeritageManager heritageBase;
	[SerializeField] float distance2show;
	private bool showFun;
	Vector3 newPosition ;
	public void Place(GPSLocation location){
		newPosition = CalculateFunPosition (location);
		if (!showFun) {
			if (location.distance < distance2show) {
				showFun = true;
				heritageBase.WarsawHeritage[heritageBase.activeOne].fun.SetActive (true);
				//location.ChangeAccuracy (5f);
			}
			heritageBase.WarsawHeritage [heritageBase.activeOne].fun.transform.position = newPosition;
		} else {
			if (location.distance > distance2show) {
				showFun = false;
				heritageBase.WarsawHeritage[heritageBase.activeOne].fun.SetActive (false);
				//location.ChangeAccuracy (1f);
			}
		}
	}
	void Update(){
		if(showFun)
		heritageBase.WarsawHeritage [heritageBase.activeOne].fun.transform.position = Vector3.Lerp (
			heritageBase.WarsawHeritage [heritageBase.activeOne].fun.transform.position, newPosition, 5f * Time.deltaTime);
	}

	Vector3 CalculateFunPosition(GPSLocation location){
		float x, y, z, normFactor;
		x = heritageBase.WarsawHeritage[heritageBase.activeOne].position.y-location.lon;
		z = heritageBase.WarsawHeritage[heritageBase.activeOne].position.x-location.lat;
		normFactor = Mathf.Sqrt (x * x + z * z);
		x *= -location.distance/normFactor;
		z *= -location.distance/normFactor;
		y = 0f;
		return new Vector3(x,y,z);
	}
}
