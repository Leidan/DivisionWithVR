using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	void Update () {
		Vector3 screenResolution = new Vector3(Screen.width, Screen.height, 0.0f); 
		Vector3 mousePosition = Input.mousePosition; 
		
		mousePosition.z = mousePosition.z; 
		mousePosition.x = Screen.width - mousePosition.x; 
		screenResolution *= 0.5f;
		
		Vector3 difference = mousePosition - screenResolution; 
		transform.Translate(difference * Time.smoothDeltaTime * -0.05f);
		
		Vector3 newPosition = transform.position; 
		//newPosition.z = 50f; 
		transform.position = newPosition;
	}
}
