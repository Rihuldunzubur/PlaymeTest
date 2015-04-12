using UnityEngine;
using System.Collections;
/// <summary>
/// Результаты. Наследую от MonoBehevior так как хочу им же выводить вверху значения.
/// </summary>
public class Results : MonoBehaviour {
	private static Results _resultSingleton;
	public static Results instance {
			get {
				if (_resultSingleton == null)
					_resultSingleton = GameObject.Find("LinesController").GetComponent<Results>();
				return _resultSingleton;
			}
			set {}// нельзя менять. 
		}

	public bool finished = false;

	public int score = 0;
	public int lives = 3;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
		if (lives>0)
			GUI.Box(new Rect(5,5,200,20), "Score "+ score.ToString()+ " lives - " + lives.ToString());
		else
		{
			GUI.Box(new Rect(20,20,Screen.width-40,Screen.height- 40), "Score "+ score.ToString()+ "\n lives - " + lives.ToString());
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
