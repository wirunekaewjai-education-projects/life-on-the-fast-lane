using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		int score = PlayerPrefs.GetInt("Score", 0);
		PlayerPrefs.DeleteKey("Score");

		int hs = PlayerPrefs.GetInt("HighScore", 0);
		if(score > hs)
		{
			PlayerPrefs.SetInt("HighScore", score);
			PlayerPrefs.Save();
		}

		TextMesh tm = GetComponent<TextMesh>();
		tm.text = score.ToString();

	}

}
