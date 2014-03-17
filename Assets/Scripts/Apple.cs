using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	//Code is derived from material on http://answers.unity3d.com
	private Color startcolor;
	private Vector3 offset, screenPoint;

	void OnMouseEnter()
	{
		startcolor = renderer.material.color;
		renderer.material.color = Color.cyan;
	}

	/*void OnMouseDown()
	{
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + gameObject.transform.position;
		transform.position = curPosition;
	}*/

	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));

	}


	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}


}
