using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
	/*public void StartGPS (){
		
	}

	public void StopGPS (){
		
	}*/
	[SerializeField] Text Latitude;
	[SerializeField] Text Longitude;
	[SerializeField] Text Info;



	IEnumerator InitializeGPS(){
		
		if (!Input.location.isEnabledByUser)
			yield break;

		Input.location.Start();

		//int maxWait = 30;
		while (Input.location.status == LocationServiceStatus.Initializing/* && maxWait > 0*/)
		{
			Info.text = "Waiting";
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
				Latitude.text = "Lat: " + Input.location.lastData.latitude.ToString ();
				Longitude.text = "Lon: " + Input.location.lastData.longitude.ToString ();
				yield return new WaitForSeconds (1);
			//}
				
		}
	}

	public void OnStartGPS(){
		StartCoroutine ("InitializeGPS");
	}

	public void OnStopGPS(){
		Input.location.Stop ();
		StopCoroutine ("GPSChecker");
		Latitude.text = "0";
		Longitude.text = "0";
		Info.text = Input.location.status.ToString();

	}

}