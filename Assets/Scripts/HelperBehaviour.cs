using UnityEngine;
using System.Collections;

public class HelperBehaviour : MonoBehaviour {
	[SerializeField] HeritageManager heritage;

	[SerializeField] float Time2Screen; //jak długo poza ekranem, by podleciałą do ekranu
	[SerializeField] float Speed2Screen;
	[SerializeField] float sqrDistance2Stop;//w tej odległości(w kwadracie) przestanie podjeżdżać do zdefiniowanego punktu przed kamerą
	[SerializeField] float Time2Point;
	[SerializeField] float Speed2Target;
	[SerializeField] float rotSpeed;
	[SerializeField] float sqrDistance2StopTarget;
	[SerializeField] new Renderer renderer;
	[SerializeField] Transform[] positions;
	[SerializeField] int position;
	bool going2Screen;
	bool going2Target;
	// Use this for initialization
	void Start () {
		renderer = GetComponentInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!going2Screen) {
			if (!renderer.isVisible) {
				going2Target = false;
				StartCoroutine (Go2Screen ());
			}
			if (!going2Target) {
				StartCoroutine (Go2Target ());
			}
		}
	}
	IEnumerator Go2Screen(){
		going2Screen = true;
		yield return new WaitForSeconds (Time2Screen);
		if (!renderer.isVisible) {
			do{
			transform.position = Vector3.MoveTowards (transform.position, positions [position].position, Speed2Screen * Time.deltaTime);
				transform.LookAt(new Vector3(0f,0.5f,0f));
			yield return null;
				print((transform.position-positions [position].position).sqrMagnitude);
			}while((transform.position-positions [position].position).sqrMagnitude>sqrDistance2Stop);
		}
		going2Screen = false;
	}
	IEnumerator Go2Target(){
		going2Target = true;
		while (going2Target) {
			Vector3 TargetInHelper = heritage.WarsawHeritage [heritage.activeOne].fun.transform.position - transform.position;
			if (sqrDistance2StopTarget > transform.position.sqrMagnitude) {
				transform.position = transform.position + transform.forward * Speed2Target * Time.deltaTime;
				Vector3 target4Rot = new Vector3 (TargetInHelper.x, 0, TargetInHelper.z);
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (target4Rot), rotSpeed * Time.deltaTime);
			} else {
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (-transform.position), rotSpeed * Time.deltaTime);
			}
			yield return null;
		}
	}
	//prawdopodobnie shit
	IEnumerator PointActivePlace(){
		yield return new WaitForSeconds (Time2Point);
		Vector3 TargetInHelper = heritage.WarsawHeritage [heritage.activeOne].fun.transform.position - transform.position;
		float angle = Vector3.Angle (transform.forward, TargetInHelper.normalized);
		if (angle < 45) {//forward
			transform.LookAt(new Vector3(0f,0.5f,0f));
		} else {
			
			if (angle < 135) {//left or right
			
			} else {//backward
			
			}
		}
		yield return null;//tak sobie bez sensu
	}
}
