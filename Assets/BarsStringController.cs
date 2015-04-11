using UnityEngine;
using System.Collections;

public class BarsStringController : MonoBehaviour {
	public BreakScript[] breaks;
	// Use this for initialization
	void Start () {
		for (int i = 0; i<breaks.Length; i++)
		{
			breaks[i].transform.position = new Vector2(i*1.5f -6.75f, transform.position.y);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
