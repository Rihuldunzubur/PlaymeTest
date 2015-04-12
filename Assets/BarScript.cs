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

	}
	void OnCollisionEnter2D(Collision2D coll)
	{

		if ( barLives >0) // Если равно нулю, то он уже уничтожен. Если меньше - то неуязвим.
		{
			//Debug.Log("Collision detected!");
			barLives--;
			GetComponent<SpriteRenderer>().color = new Color(1,0,0);

			if (barLives ==0)// то уничтожаем и начисляем очки.
			{
				DestroyBar();
			}
		}
		
	}

	
	void DestroyBar()
	{
		transform.parent.GetComponent<BarsStringController>().DecBars(this);
		Destroy(this.gameObject);
		Results.instance.score ++;
		if (UnityEngine.Random.Range(0,100)<10)
		{
			GameObject bonus = Instantiate (Resources.Load("Bonus")) as GameObject;
			bonus.transform.position = this.transform.position;
			bonus.SendMessage("Generate");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
