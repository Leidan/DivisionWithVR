using UnityEngine;
using System.Collections;

public class FenceScript : MonoBehaviour {
	public Vector3 size = new Vector3(100, 100, 100);

	public void rescale(Vector3 newSize)
	{
		transform.localScale = newSize;
	}
	// Use this for initialization
	void Start () {
		//rescale(size);
	}
}
