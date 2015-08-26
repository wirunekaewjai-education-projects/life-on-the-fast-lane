using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public TextMesh highScore;

	// Use this for initialization
	void Start ()
	{
		int hs = PlayerPrefs.GetInt("HighScore", 0);
		if(hs > 0)
            highScore.text = "High Score : "+hs.ToString();
		else
			highScore.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Application.loadedLevel == 0)
			if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}
}
