using UnityEngine;
using System.Collections;
/// <summary>
/// Бита. Передвижение, рост.
/// </summary>
public class ClubScript : MonoBehaviour {
	public Camera cam;// для преобразования координат
	public Vector3 mousepos;
	bool followMouse = !true;// вначале мышь не нажата.

	// Use this for initialization
	public  Vector3 getInWorldCoords(Vector3 inCoords)
	{

		Vector3 screenPos = cam.WorldToScreenPoint(inCoords);
		//screenPos.z+=1;
		return screenPos;
	}
	public  Vector3 getInScreenCoords(Vector3 inCoords)
	{
		Vector3 screenPos = cam.ScreenToWorldPoint(inCoords);
		//screenPos.z+=1;
		return screenPos;
	}


	void Start () {
	
	}

	void OnMouseDown()
	{
		followMouse= true;
	}
	void OnMouseUp()
	{
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
