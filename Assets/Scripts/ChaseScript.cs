using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChaseScript : MonoBehaviour 
{
	public ManagerScript manager;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Respawn")
		{
			manager.aliving = false;
			Invoke("ChangeScene", 0.5f);
		}
	}

	void ChangeScene()
	{
		PlayerPrefs.SetInt("Score", manager.score);
		PlayerPrefs.Save();

		Application.LoadLevel(2);
	}
}
