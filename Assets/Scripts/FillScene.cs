using UnityEngine;
using System.Collections;

public class FillScene : MonoBehaviour {

	public GameObject fenceInstance;
	private Vector3 fenceSize;
	private Vector3 fencePos;
	private Vector3 distBetweenFences;
	private Vector3 fenceDir;
	private Quaternion fenceRotation;
	private Vector2 fenceDimensions;
	private Vector2 perimeterOffset;

	// Use this for initialization
	void Start () {
		fenceSize = new Vector3(1, 1, 1);
		fencePos = new Vector3(CameraMovement.MIN_X, 0, CameraMovement.MAX_Z+5);

		fenceDimensions.x = Mathf.Ceil(((CameraMovement.MAX_X - CameraMovement.MIN_X)*40)/fenceSize.x);
		fenceDimensions.y = Mathf.Ceil(((CameraMovement.MAX_Z - CameraMovement.MIN_Z)*40)/fenceSize.x);

		distBetweenFences = (fenceSize*12);
		fenceDir = Vector3.Scale(distBetweenFences,Vector3.right);
		createFence();

	}

	public void createFence()
	{
		fenceInstance = (GameObject)Instantiate(Resources.Load("fence1"), fencePos, Quaternion.identity);
		fenceInstance.transform.localScale = fenceSize;
		fenceInstance = (GameObject)Instantiate(Resources.Load("fence1"), fencePos + fenceDir, Quaternion.identity);
		Debug.Log(fenceInstance.renderer.bounds.max.y);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
