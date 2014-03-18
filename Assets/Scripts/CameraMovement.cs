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
	public Vector3 screenResolution;
	public Vector3 mousePosition;
	public Vector3 difference;
	public float edgeOffset = 0.025f*Screen.width;

	void Start(){
		transform.position = new Vector3(100.0f, 11.0f, 100.0f);
	}

	void Update () {
		screenResolution = new Vector3(Screen.width, Screen.height, 0.0f);
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