using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
	/*public void StartGPS (){
		
	}

	public void StopGPS (){
		
	}*/
	[SerializeField] Text Name;
	[SerializeField] Text Latitude;
	[SerializeField] Text Longitude;
	[SerializeField] Text Info;
	[SerializeField] Text Distance;
	[SerializeField] HeritageManager heritages;
	[SerializeField] FunPlacer funPlacer;
	[SerializeField] GameObject playerHelper;
	public float lat;
	public float lon;
	public float distance;//do aktywnego zabytku

	IEnumerator InitializeGPS(){
		if (playerHelper.activeSelf)
			playerHelper.SetActive (false);
		
		if (!Input.location.isEnabledByUser)
			yield break;

		Input.location.Start();

		//int maxWait = 30;
		while (Input.location.status == LocationServiceStatus.Initializing/* && maxWait > 0*/)
		{
			Info.text = "Waiting";
			if (playerHelper.activeSelf)
				playerHelper.SetActive (false);
			yield return new WaitForSeconds(1);
			//maxWait--;
		}
			
		/*if (maxWait < 1)
		{
			Info.text = Input.location.status.ToString();
			yield break;
		}*/
			
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Info.text = Input.location.status.ToString();
			yield break;
		}
		else
		{
			if (!playerHelper.activeSelf)
				playerHelper.SetActive (true);
			//Info.text = Input.location.status.ToString();
			StartCoroutine ("GPSChecker");
		}
	}

	IEnumerator GPSChecker(){
		int counter = 0;
		for(;;){
			
			Info.text = Input.location.status.ToString() + " " + counter.ToString();
			counter++;
			//if (Input.location.status == LocationServiceStatus.Running) {
				//Info.text = Input.location.status.ToString ();
			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude;
			SetClosestHeritage ();
			distance = DistanceCalculator.Calculate (
				lat,
				lon,
				heritages.WarsawHeritage [heritages.activeOne].position.x,
				heritages.WarsawHeritage [heritages.activeOne].position.y)*1000f;
			Latitude.text = "Lat: " + lat.ToString ();
			Longitude.text = "Lon: " + lon.ToString ();
			Distance.text = "Dist: " + distance.ToString ();
			funPlacer.Place (this);
			yield return new WaitForSeconds (1);
			//}
				
		}
	}
	void SetClosestHeritage(){
		float min = Mathf.Infinity;
		for(int i =0;i <heritages.WarsawHeritage.Length;i++){
			if(!heritages.WarsawHeritage[i].visited){
			float temp = Mathf.Pow (lat-heritages.WarsawHeritage [i].position.x,2)
				+ Mathf.Pow (lon-heritages.WarsawHeritage [i].position.y,2);
			if (temp < min) {
				heritages.activeOne = i;
				min = temp;
				}
			}
		}
		Name.text = heritages.WarsawHeritage [heritages.activeOne].name;
	}
	public void OnStartGPS(){
		if(Input.location.status!=LocationServiceStatus.Running)
			StartCoroutine ("InitializeGPS");
	}

	public void OnStopGPS(){
		Input.location.Stop ();
		StopCoroutine ("GPSChecker");
		Latitude.text = "0";
		Longitude.text = "0";
		Info.text = Input.location.status.ToString();

	}
	public void ChangeAccuracy(float accuracy){
		Input.location.Stop ();
		Input.location.Start (accuracy);
	}
}