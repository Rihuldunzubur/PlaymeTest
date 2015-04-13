using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BarRowsController : MonoBehaviour {

	public int GetSecondLineBreak(int inNum)
	{
		try {
			if (gamefield.Count>=1)
				return gamefield[gamefield.Count-1].lBreaks[inNum].barLives;
			else return 1;
		}
		catch (ArgumentException) {return 1;}// то есть блок уничтожен, а значит он не был неразрушимым.
	}

	public List<BarsStringController> gamefield;
	// Use this for initialization
	void Start () {
		gamefield = new List<BarsStringController>();
		GameObject cntrlr;
		cntrlr = Instantiate(Resources.Load("BarsString")) as GameObject;
		gamefield.Add(cntrlr.GetComponent<BarsStringController>());
		gamefield[gamefield.Count-1].Init();
		cntrlr.transform.position = new Vector3(0, 4.75f,0);
		for (int i = 0; i<4; i++)
		{
			GenerateOneMore();
		}
		StartCoroutine(AddRow());
	}
	IEnumerator AddRow()
	{
		while (true) 
		{
			yield return new WaitForSeconds(60);
			if (gamefield .Count>=17)
			{
				BarsStringController tmp = gamefield[0];
				gamefield.Remove(tmp);
				Destroy(tmp.gameObject);
			}
			GenerateOneMore();
		}
	}

	public void GenerateOneMore()
	{
		GameObject cntrlr;
		foreach( BarsStringController row in gamefield)
		{
			row.transform.Translate(0,-0.5f,0);
		}
		cntrlr = Instantiate(Resources.Load("BarsString")) as GameObject;
		cntrlr.GetComponent<BarsStringController>().Init();
		gamefield.Add(cntrlr.GetComponent<BarsStringController>());
		cntrlr.transform.position = new Vector3(0, 4.75f,0);
	}
	
	
	public void DestroyChild(BarsStringController sender)
	{
		gamefield.Remove(sender);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
