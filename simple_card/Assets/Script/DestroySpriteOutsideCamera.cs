using UnityEngine;
using System.Collections;

public class DestroySpriteOutsideCamera : MonoBehaviour {

	void OnBecameInvisible()
	{
		Destroy (gameObject);
		if(!GameManager.manager.isTimer){
			GameManager.manager.end_count -= 1;
		}
	}


}
