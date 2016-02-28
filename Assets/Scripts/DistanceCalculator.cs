using UnityEngine;
using System.Collections;

public class DistanceCalculator{

	static public float Calculate(float Lat1, float Lon1, float Lat2, float Lon2){
		float diameter=12756.274f,a,b;//średnica Ziemi na równiku [km]
		a=(Lon2-Lon1)*Mathf.Cos(Lat1*Mathf.PI/180f);
		b=(Lat2-Lat1);
		return Mathf.Sqrt(a*a+b*b)*Mathf.PI*diameter/360f;//[km]
	}
	static public float Calculate2(float lat1, float long1, float lat2, float long2){
		float dlong = (long1 - long2);

		float dvalue = (Mathf.Sin(lat1 * Mathf.Deg2Rad) * Mathf.Sin(lat2 * Mathf.Deg2Rad))
			+ (Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad)
				* Mathf.Cos(dlong * Mathf.Deg2Rad));

		float dd = Mathf.Acos(dvalue) * Mathf.Rad2Deg;

		float km = (dd * 111.302f);
		return km;
		}
}
