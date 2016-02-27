using UnityEngine;
using System.Collections;

public class DistanceCalculator{

	static public float Calculate(float Lon1, float Lat1, float Lon2, float Lat2){
		float diameter=12756.274f,a,b;//średnica Ziemi na równiku [km]
		a=(Lon2-Lon1)*Mathf.Cos(Lat1*Mathf.PI/180f);
		b=(Lat2-Lat1);
		return Mathf.Sqrt(a*a+b*b)*Mathf.PI*diameter/360f;//[km]
	}
}
