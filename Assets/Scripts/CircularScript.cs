using UnityEngine;
using System.Collections.Generic;

public class CircularScript : MonoBehaviour 
{
	public List<GameObject> platePrefabs = new List<GameObject>();

	public float speed = 10;
	public float length = 50;
	public int plateCount = 5;

	private List<GameObject> plates = new List<GameObject>();
	private ManagerScript manager;

	// Use this for initialization
	void Start () 
	{
		/*
		float i1 = speed / 10f;
		float i2 = length / 10f;

		int count = (int)(i1 * i2);
		*/

		int count = plateCount;
		for (int i = 0; i < count; i++) 
		{
			int index = Random.Range(0, platePrefabs.Count);
			GameObject p = Instantiate(platePrefabs[index], new Vector3(0, 0, i * length), Quaternion.identity) as GameObject;
			plates.Add(p);
		}

		manager = GetComponent<ManagerScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!manager.aliving)
			return;

		foreach (GameObject plate in plates)
		{
			Transform t = plate.transform;
			t.Translate(0, 0, -speed * Time.fixedDeltaTime);

			if(t.position.z <= -length)
				t.position += new Vector3(0, 0, length * (plates.Count - 1));
		}
	}
}
