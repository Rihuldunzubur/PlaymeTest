using UnityEngine;
using System.Collections;
/// <summary>
/// Скрипт мяча. Нужен для увеличения скорости и установки на начальное положение.
/// </summary>
public class BallScript : MonoBehaviour {
	public float speedKoef=1f;
	public Vector2 speed;
	// Use this for initialization
	void Start () {
		//rigidbody2D.velocity = speed;
		rigidbody2D.AddForce(speed);
		Debug.Log(rigidbody2D.velocity);

	}

	/// <summary>
	/// Если столкнулись с кирпичом.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnCollisionEnter2D(Collision2D coll)
	{

	}

	// Update is called once per frame
	void Update () {
	
	}
}
