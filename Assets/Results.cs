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

	/// <summary>
	/// Этот метод извлекает имя из таблиы рекордов.
	/// ПОлагаем, что у нас всего 10 позиций. 
	/// </summary>
	/// <returns>The table row name.</returns>
	/// <param name="inRowNum">In row number.</param>
	string GetTableRowName(int inRowNum)
	{
		if (inRowNum>10 || inRowNum<=0) return "NULL";
		else
		{
			return PlayerPrefs.GetString("RecordName"+inRowNum.ToString());
		}
	}
	/// <summary>
	/// Извлекает из таблицы число очков.
	/// </summary>
	/// <returns>The table row score.</returns>
	/// <param name="inRowNum">In row number.</param>
	int GetTableRowScore(int inRowNum)
	{
		if (inRowNum>10 || inRowNum<=0) return -1;
		else
		{
			return PlayerPrefs.GetInt("RecordScore"+inRowNum.ToString());
		}
	}
	/// <summary>
	/// Записывает в таблицу.
	/// </summary>
	/// <param name="inName">In name.</param>
	/// <param name="inScore">In score.</param>
	/// <param name="inRowNum">In row number.</param>
	void SetRow(string inName, int inScore, int inRowNum)
	{
		// имя будем вводить как текущую дату.
		PlayerPrefs.SetString("RecordName"+inRowNum.ToString(), inName);
		PlayerPrefs.SetInt("RecordScore"+inRowNum.ToString(),inScore);
		PlayerPrefs.Save();
	}

	public int score = 0;
	public int lives = 3;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
	}
	void UpdateTable()
	{
		bool shallBreak = false;
		for(int i = 1; i<=10 && !shallBreak; i++)
		{
			if (score > GetTableRowScore(i))
			{
				for (int j = 10; j>i; j--) SetRow(GetTableRowName(j+1),GetTableRowScore(j+1),j);
				string s = System.DateTime.Now.ToString();
				SetRow(s,score, i);
				shallBreak = true;
			}
		}
	}

	void OnGUI()
	{
		if (lives>0)
			GUI.Box(new Rect(5,5,200,20), "Score "+ score.ToString()+ " lives - " + lives.ToString());
		else
		{
			string s = "";
			UpdateTable();
			for (int i = 1; i<11; i++)
			{
				s += GetTableRowName(i) + "\v - \v"+ GetTableRowScore(i).ToString() + '\n';
 			}
			GUI.Box(new Rect(20,20,Screen.width-40,Screen.height- 40), s);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) Application.LoadLevel("Scene");
	}
}
