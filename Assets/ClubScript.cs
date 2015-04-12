using UnityEngine;
using System.Collections;
/// <summary>
/// Бита. Передвижение, рост.
/// </summary>
public class ClubScript : MonoBehaviour {
	public Camera cam;// для преобразования координат
	public Vector3 mousepos;
	bool followMouse = !true;// вначале мышь не нажата.
	public BallScript ball;
	public float maxTimer;
	public float timer;
	/// <summary>
	/// левый и правый боковой шарик. 
	/// </summary>
	public Transform[] borders;
	// Use this for initialization
	public  Vector3 getInWorldCoords(Vector3 inCoords)
	{
		Vector3 screenPos = cam.WorldToScreenPoint(inCoords);
		return screenPos;
	}
	public  Vector3 getInScreenCoords(Vector3 inCoords)
	{
		Vector3 screenPos = cam.ScreenToWorldPoint(inCoords);
		return screenPos;
	}

	void Start () {	
	}

	IEnumerator WaitForTime()
	{
		timer = maxTimer;
		while (timer >0)
		{
			yield return new WaitForEndOfFrame();
			timer-= Time.deltaTime;
		}
	}



	void OnMouseDown()
	{
		if (!ball.ready)
		{
			StartCoroutine(WaitForTime());
		}
		followMouse= true;
	}


	void OnMouseUp()
	{
		if (timer >=0 && !ball.ready)
		{
			ball.Init();
		}
		timer = maxTimer;
		StopAllCoroutines();
		
		followMouse= !true;
	}
	/// <summary>
	/// Изменяет размер биты.
	/// </summary>
	/// <param name="more">Если истина - то больше. <c>true</c> more.</param>
	public void ChangeSize(bool more)
	{
		float size = transform.localScale.x;
		if (more)
		{
			if (size <1.4f)
			{
				size+=0.2f;
				transform.localScale = new Vector3(size,1,1);
				foreach(Transform border in borders)
				{
					border.localScale = new Vector3(1/size, 1,1);
				}
			}
		}
		else
		{
			if (size >0.5f)
			{
				size-=0.2f;
				transform.localScale = new Vector3(size,1,1);
				foreach(Transform border in borders)
				{
					border.localScale = new Vector3(1/size, 1,1);
				}
			}
		}
	}

	/// <summary>
	/// Столкновение с бонусом.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("Bonus");
		if (coll.name == "Bonus")
		{
			BonusScript bonus = coll.GetComponent<BonusScript>();
			switch (bonus.bonusType)
			{
			case 0: // ничего, но на всякий случай.
				break;
			case 1:
				ball.ChangeSpeed(true);
				break;
			case 2:
				ball.ChangeSpeed(false);
				break;
			case 3:
				ChangeSize(true);
				break;
			case 4:
				ChangeSize (false);
				break;
			}
		}
		Destroy(coll.gameObject);
	}


	// Update is called once per frame
	void Update () {
		if (followMouse)
		{
			mousepos = getInScreenCoords( Input.mousePosition);
			mousepos.y = transform.position.y;
			mousepos.z = 0;
			transform.position = mousepos;
		}
	}
}
