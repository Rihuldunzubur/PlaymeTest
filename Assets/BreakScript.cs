using UnityEngine;
using System.Collections;

public class BreakScript : MonoBehaviour {
	/// <summary>
	/// Количество ударов, которое может выдержать кирпич. Если ноль - то кирпич должен быть уничтожен. Если меньше нуля - значит,
	/// кирпич неразрушим.
	/// </summary>
	public int breakLives;
	/// <summary>
	/// Инициатор. Здесь же кирпичи перекрашиваются в нужный цвет.
	/// </summary>
	/// <param name="inType">Число жизней кирпича, если меньше нуля - то неуязвимый.</param>
	public void Init( int inType)
	{
		breakLives = inType;

	}

	public void CollidedWithBall()
	{
		Debug.Log("bang!");
		if ( breakLives >0) // Если равно нулю, то он уже уничтожен. Если меньше - то неуязвим.
		{

			breakLives--;
			if (breakLives ==0)// то уничтожаем и начисляем очки.
			{
				DestroyBreak();
			}
		}
	}
	
	void DestroyBreak()
	{
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
