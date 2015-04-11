using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarRowsController : MonoBehaviour {


	List<BarsStringController> gamefield;
	// Use this for initialization
	void Start () {
		gamefield = new List<BarsStringController>();
		GameObject cntrlr;
		for (int i = 0; i<5; i++)
		{
			cntrlr = Instantiate(Resources.Load("BarsString")) as GameObject;
			gamefield.Add(cntrlr.GetComponent<BarsStringController>());
			cntrlr.transform.position = new Vector3(0, 4.75f-0.5f*i,0);
		}
		StartCoroutine(AddRow());
	}
	IEnumerator AddRow()
	{
		GameObject cntrlr;
		while (true) 
		{
			yield return new WaitForSeconds(1);
			if (gamefield .Count<9)
			{
				foreach( BarsStringController row in gamefield)
				{
					row.transform.Translate(0,-0.5f,0);
				}
				cntrlr = Instantiate(Resources.Load("BarsString")) as GameObject;
				gamefield.Add(cntrlr.GetComponent<BarsStringController>());
				cntrlr.transform.position = new Vector3(0, 4.75f,0);
			}
		}
	}

	public void DestroyChild(BarsStringController sender)
	{
		gamefield.Remove(sender);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
