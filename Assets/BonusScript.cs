using UnityEngine;
using System.Collections;

public class BonusScript : MonoBehaviour {
	public int bonusType = 0;

	public void Generate()
	{
		bonusType = Random.Range(1,5);
		bonusType = 4;
		this.name = "Bonus";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
