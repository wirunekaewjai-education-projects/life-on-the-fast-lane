using UnityEngine;
using System.Collections;

public class NavButtonScript : MonoBehaviour 
{
	public int levelIndex;

	void OnMouseDown() 
	{
		Application.LoadLevel(levelIndex);
	}
}
