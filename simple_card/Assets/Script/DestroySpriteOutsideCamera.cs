using UnityEngine;
using System.Collections;

public class DestroySpriteOutsideCamera : MonoBehaviour {

	private GameManager manager;
	void Start(){
//		GameObject obj = transform.Find("GameManager") as GameObject;
	}
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
