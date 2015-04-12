using UnityEngine;
using System.Collections;

public class BonusScript : MonoBehaviour {
	public int bonusType = 0;

	public void Generate()
	{
		bonusType = Random.Range(1,5);
		Color clr = new Color(0,0,0,0);
		 switch (bonusType)
		{
		case 1:
			clr = new Color(1,0,0);
			break;
		case 2:
			clr = new Color(0,1,0);
			break;
		case 3:
			clr = new Color(0,0,1);
			break;
		case 4:
			clr = new Color(1,1,1);
			break;
		}
		GetComponent<SpriteRenderer>().color = clr;
		this.name = "Bonus";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
