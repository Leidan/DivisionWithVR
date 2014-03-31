//modified unity camera script mouse orbit
//edited by Daniel Zhao

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;

	int xMinLimit = -90;
	int xMaxLimit = 90;

	int yMinLimit = -50;
	int yMaxLimit = 60;
	
	private float x = 0.0f;
	private float y = 0.0f;

	void Start()
	{
		transform.position = new Vector3(100.0f, 11.0f, 100.0f);
	}

	void Update () 
	{
		x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
		y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

		x = ClampAngle(x, xMinLimit, xMaxLimit);
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		
		Quaternion rotation = Quaternion.Euler(y, x, 0);
		
		transform.rotation = rotation;
	}

	//code from the unity camera script mouse orbit
	float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
}