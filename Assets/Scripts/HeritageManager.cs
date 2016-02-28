using UnityEngine;
using System.Collections;

public class HeritageManager : MonoBehaviour {
	public Heritage[] WarsawHeritage;
	public int activeOne;


}
[System.Serializable]
public class Heritage{
	public string name;
	public Vector2 position;
	public string info;
	public GameObject fun;
	public bool visited;
}
