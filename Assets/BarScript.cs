using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour {
	/// <summary>
	/// Количество ударов, которое может выдержать кирпич. Если ноль - то кирпич должен быть уничтожен. Если меньше нуля - значит,
	/// кирпич неразрушим.
	/// </summary>
	public int barLives;
	/// <summary>
	/// Инициатор. Здесь же кирпичи перекрашиваются в нужный цвет.
	/// </summary>
	/// <param name="inType">Число жизней кирпича, если меньше нуля - то неуязвимый.</param>
	public void Init( int inType)
	{
		barLives = inType;
		if (barLives <=0)barLives = -1;
		if (barLives ==3) barLives = 4;// потому что не три удара, а четыре.
		Color clr = new Color(1,1,1);
		switch (barLives)
		{
			case -1: clr = new Color(1,1,1);break;
			case 1: clr = new Color(0,1,0); break;
			case 2: clr = new Color(1,0.5f,0); break;
			case 4: clr = new Color(1,0,0);break;
		}
		GetComponent<SpriteRenderer>().color = clr;
	}
	void OnCollisionEnter2D(Collision2D coll)
	{

		if ( barLives >0) // Если равно нулю, то он уже уничтожен. Если меньше - то неуязвим.
		{
			//Debug.Log("Collision detected!");
			barLives--;
			if (barLives ==0)// то уничтожаем и начисляем очки.
			{
				DestroyBar();
			}
		}
		
	}

	
	void DestroyBar()
	{
		transform.parent.GetComponent<BarsStringController>().DecBars(this);
		StartCoroutine(IDestroy());
		Results.instance.score ++;
		if (UnityEngine.Random.Range(0,100)<10)
		{
			GameObject bonus = Instantiate (Resources.Load("Bonus")) as GameObject;
			bonus.transform.position = this.transform.position;
			bonus.SendMessage("Generate");
		}
	}

	IEnumerator IDestroy()
	{
		Color clr;
		GetComponent<BoxCollider2D>().enabled = false;
		for (int i = 25; i>=0; i--)
		{
			yield return new WaitForFixedUpdate();
			clr = GetComponent<SpriteRenderer>().color;
			clr.a = (float)i/25;
			GetComponent<SpriteRenderer>().color = clr;
		}
		Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
