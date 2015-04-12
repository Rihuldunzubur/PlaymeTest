using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarsStringController : MonoBehaviour {
	public BarScript[] breaks;
	public List<BarScript> lBreaks;
	BarRowsController controller;
	// Use this for initialization
	public void Init () {
		controller = GameObject.Find("LinesController").GetComponent<BarRowsController>();
		for (int i = 0; i<breaks.Length; i++)
		{
			breaks[i].transform.position = new Vector2(i*1.5f -6.75f, transform.position.y);
			lBreaks.Add(breaks[i]);
			if (controller.GetSecondLineBreak(i) >0)
			{
				if (i >0 && breaks[i-1].barLives>0) 
					breaks[i].Init(Random.Range(0,4));
				else
					breaks[i].Init(Random.Range(1,4));
			}
			else
				breaks[i].Init(Random.Range(1,4));
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
