using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	//Code is derived from material on http://answers.unity3d.com
	private Color startcolor;
	private Vector3 offset, screenPoint;
	//Newly added variables
	private bool dragging = false;
	private float distance;


	void OnMouseEnter()
	{
		startcolor = renderer.material.color;
		renderer.material.color = Color.cyan;
	}


	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}

	void OnMouseDown()
	{	
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);	
		dragging = true;
	}

	void Update()
	{
		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			transform.position = rayPoint;	
		}
	}

}
