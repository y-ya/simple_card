using UnityEngine;
using System.Collections;

public class DestroySpriteOutsideCamera : MonoBehaviour {

	bool isVisible = false;

	private GameManager manager;
	void Start(){
//		GameObject obj = transform.Find("GameManager") as GameObject;
	}

	void OnBecameVisible()
	{
		isVisible = true;
	}

	void OnBecameInvisible()
	{
		if( isVisible)
			Destroy (gameObject);

		if(GameManager.manager != null && !GameManager.manager.isTimer){
			GameManager.manager.end_count -= 1;
		}
	}
}
