//Programmers: Daniel Zhao, Zeshawn Shaheen, Tim Lee
//Comp 253 Virtual Reality
//Learning Division with VR

//some code is taken from http://answers.unity3d.com/questions/467192/how-to-set-boundaries-with-camera-movement.html
//and edited for our project


using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public static int MIN_X = 80;
	public static int MAX_X = 120;

	public static int MIN_Y = 11;
	public static int MAX_Y = 11;

	public static int MIN_Z = 80;
	public static int MAX_Z = 120;

	private float cameraSpeed;
	private Vector3 cameraRotation;
	public Vector3 screenResolution;
	public Vector3 mousePosition;
	public Vector3 difference;
	public float edgeOffset = 0.025f*Screen.width;

	void Start(){
		cameraRotation = new Vector3(45, 0, 0);
		screenResolution = new Vector3(Screen.width, Screen.height, 0.0f);

		transform.position = new Vector3(100.0f, 11.0f, 100.0f);
		transform.localEulerAngles = cameraRotation;
	}

	void Update () {

		mousePosition = Input.mousePosition;

		if(mousePosition.x > (screenResolution.x - edgeOffset) || 
		   mousePosition.y > (screenResolution.y - edgeOffset) ||
		   mousePosition.x <  edgeOffset ||
		   mousePosition.y <  edgeOffset)
		{
			cameraSpeed = 0.04f;
			difference = mousePosition - (0.5f*screenResolution);
			moveCamera (difference, cameraSpeed);
		}
		else if(cameraSpeed > 0.0f)
		{
			cameraSpeed -= 0.002f;
			moveCamera (difference, cameraSpeed);
		}
		else{
			cameraSpeed = 0.0f;
		}
	}

	void moveCamera (Vector3 cameraDest, float speed){
		transform.Translate(cameraDest * speed * Time.smoothDeltaTime, Space.Self);
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
			Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
			Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
	}
}

/*
Vector3 screenResolution = new Vector3(Screen.width, Screen.height, 0.0f); 
		Vector3 mousePosition = Input.mousePosition; 
		
		mousePosition.z = mousePosition.z; 
		mousePosition.x = Screen.width - mousePosition.x; 
		screenResolution *= 0.5f;
		
		Vector3 difference = mousePosition - screenResolution; 
		transform.Translate(difference * Time.smoothDeltaTime * -0.05f);
		
		Vector3 newPosition = transform.position; 
		//newPosition.z = 50f; 
		transform.position = newPosition;*/

/*
// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.
// Edited by Daniel Zhao

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	//
	// VARIABLES
	//
	
	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	float yMinLimit = -20;
	float yMaxLimit = 80;
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?
	
	//
	// UPDATE
	//
	
	void Update () 
	{
		// Get the left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}
		
		// Disable movements on button release
		if (!Input.GetMouseButton(0)) isRotating=false;
		if (!Input.GetMouseButton(1)) isPanning=false;
		if (!Input.GetMouseButton(2)) isZooming=false;
		
		// Rotate camera along X and Y axis
		if (isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			//pos *= turnSpeed;

			//pos.y = ClampAngle(pos.y, yMinLimit, yMaxLimit);

			//Quaternion rotation = Quaternion.Euler(pos.y, pos.x, 0);
			//transform.rotation = rotation;

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}
		
		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = pos.y * zoomSpeed * transform.forward; 
			transform.Translate(move, Space.World);
		}
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
*/