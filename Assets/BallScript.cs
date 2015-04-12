using UnityEngine;
using System.Collections;
/// <summary>
/// Скрипт мяча. Нужен для увеличения скорости и установки на начальное положение.
/// </summary>
public class BallScript : MonoBehaviour {
	public float speedKoef=1f;
	public Vector2 speed;
	public Transform club;
	public bool ready = !true;


	void Start()
	{

		//Init();
	}

	// Use this for initialization
	public void Init () {
		ready = true;
		speedKoef = 1;
		rigidbody2D.AddForce(speed);
		Debug.Log(rigidbody2D.velocity);
		StartCoroutine(IncreaseSpeed());
	}


	/// <summary>
	/// Меняет скорость шарика "сверху", то есть бонусами. Или увеличивает, или уменьшает.
	/// </summary>
	/// <param name="faster">Если true- то скорость увеличится.<c>true</c> faster.</param>
	public void ChangeSpeed(bool faster)
	{
		Debug.Log(faster);
		Vector3 vel;
		if (faster){
			vel = rigidbody2D.velocity / speedKoef;
			speedKoef*=1.05f;
			vel *= speedKoef;
			rigidbody2D.velocity = vel;
		}
		else{
			vel = rigidbody2D.velocity / speedKoef;
			speedKoef*=0.90f;
			vel *= speedKoef;
			rigidbody2D.velocity = vel;
		}
	}
	/// <summary>
	/// Ускорение шарика.
	/// </summary>
	/// <returns>The speed.</returns>
	IEnumerator IncreaseSpeed()
	{
		Vector3 vel;
		while (true)
		{
			yield return new WaitForSeconds(30);
			Debug.Log(rigidbody2D.velocity);
			vel = rigidbody2D.velocity / speedKoef;
			speedKoef*=1.05f;
			vel *= speedKoef;
			rigidbody2D.velocity = vel;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!ready) {
			transform.position = new Vector3(
				club.position.x,
				club.position.y +0.6f,
				0);
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.name == "Borders")
		{
			Results.instance.lives--;
			if (Results.instance.lives>0)
			{
				rigidbody2D.velocity = Vector2.zero;
				club.GetComponent<ClubScript>().StopAllCoroutines();
				club.GetComponent<ClubScript>().timer = 
					club.GetComponent<ClubScript>().maxTimer;
				ready = false;
				speedKoef = 1;
			}
		}
	}
}
