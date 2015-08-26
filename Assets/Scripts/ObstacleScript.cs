using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleScript : MonoBehaviour
{
	public List<GameObject> obstaclePrefabs = new List<GameObject>();

	public float[] obstacleDistance = new float[2];

	public int maxObstacles = 5;

	private CircularScript circular;
	private ManagerScript manager;

	private List<GameObject> obstacles = new List<GameObject>();

	private float maxFar;
	private float currentFar;

	// Use this for initialization
	void Start ()
	{
		circular = GetComponent<CircularScript>();
		manager = GetComponent<ManagerScript>();

		maxFar = (circular.length / 2f) + (circular.length * (circular.plateCount - 1));
		Invoke("StartWave", manager.timeToBegin);
	}

	void StartWave()
	{
		StartCoroutine("Wave");
	}

	IEnumerator Wave()
	{
		//Debug.Log("Begin Wave");
		currentFar = circular.length;

		int number = 0;
		while(manager.aliving)
		{
			while(currentFar < maxFar && obstacles.Count < maxObstacles)
			{
				int index = 0;
				int random = Random.Range(0, 11);
				
				if(random > 5)
					index = 1;
				
				float distance = Random.Range(obstacleDistance[0], obstacleDistance[1]);
				
				float x = manager.lanes[index];
				float z = currentFar + distance;
				
				if(z >= maxFar)
					break;

				int prefabIndex = Random.Range(0, obstaclePrefabs.Count);
				
				GameObject g = Instantiate(obstaclePrefabs[prefabIndex], new Vector3(x, 0, z), Quaternion.identity) as GameObject;
				g.name = "Obstacle ["+number+"]";
				number++;

				if(number >= maxObstacles)
					number -= maxObstacles;

				obstacles.Add(g);
				
				currentFar += distance;
				yield return new WaitForSeconds(0.25f);
            }

			//Debug.Log("Next");
			yield return new WaitForSeconds(0.25f);
        }
		
		//Debug.Log("End Wave");
    }
    
    // Update is called once per frame
    void Update () 
    {	
		if(!manager.aliving)
			return;

		float decrease = circular.speed * Time.fixedDeltaTime;

		currentFar -= decrease;

		List<GameObject> deletes = new List<GameObject>();
		foreach (GameObject obstacle in obstacles) 
		{
			Transform t = obstacle.transform;
			t.Translate(0, 0, -decrease);

			if(t.position.z <= -circular.length)
				deletes.Add(obstacle);
		}
		
		foreach (GameObject obstacle in deletes) 
		{
			obstacles.Remove(obstacle);
			Destroy(obstacle);
		}

    }
    
}
