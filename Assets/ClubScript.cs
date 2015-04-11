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
	float timer;

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
		if (timer >=0)
		{
			ball.Init();
		}
		timer = maxTimer;
		StopAllCoroutines();
		
		followMouse= !true;
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
