using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour 
{
	public bool aliving = true;
	
	public float timeToBegin = 3;
	public float[] lanes = new float[2];

	public TextMesh scoreText;
	public int score;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("IncreaseScore", timeToBegin, 1);
	}
	
	void IncreaseScore()
	{
		if(!aliving)
			return;

		score++;
		scoreText.text = "Score : " + score;
	}
}
