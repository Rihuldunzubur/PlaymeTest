using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarsStringController : MonoBehaviour {
	public BarScript[] breaks;
	public List<BarScript> lBreaks;
	BarRowsController controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("LinesController").GetComponent<BarRowsController>();
		for (int i = 0; i<breaks.Length; i++)
		{
			breaks[i].transform.position = new Vector2(i*1.5f -6.75f, transform.position.y);
			lBreaks.Add(breaks[i]);
		}
	}
	public void DecBars(BarScript sender)
	{
		lBreaks.Remove(sender);
		if (lBreaks.Count ==0) 
		{
			controller.DestroyChild(this);
			Destroy(this.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
