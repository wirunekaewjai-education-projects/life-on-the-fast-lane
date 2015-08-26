using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour 
{
	public GameObject car;

	private ManagerScript manager;
	private int laneIndex;
	private bool changing;

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		laneIndex = 0;
		changing = false;

		manager = GetComponent<ManagerScript>();
		anim = car.GetComponent<Animator>();
		anim.SetInteger("Turning", -1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!manager.aliving)
			return;

		bool isMouseDown = Input.GetMouseButtonDown(0);
		bool isTouchDown = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;

		if((isMouseDown || isTouchDown) && !changing)
		{
			int toIndex = (laneIndex == 0) ? 1 : 0;
			StartCoroutine("ChangeLaneTo", toIndex);
		}

	}

	IEnumerator ChangeLaneTo(int index)
	{
		changing = true;
		laneIndex = index;
		anim.SetInteger("Turning", index);
		for(float t = 0; t <= 1f; t += 0.1f)
		{
			Vector3 oldPos = car.transform.position;
			float x = Mathf.Lerp(oldPos.x, manager.lanes[index], t);
			
			if(!manager.aliving)
			{
				StopCoroutine("ChangeLaneTo");
				break;
			}
            
            car.transform.position = new Vector3(x, oldPos.y, oldPos.z);
			yield return new WaitForFixedUpdate();
		}
		anim.SetInteger("Turning", -1);
		changing = false;
	}
}
