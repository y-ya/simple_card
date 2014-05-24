using UnityEngine;
using System.Collections;

public class DestroySpriteOutsideCamera : MonoBehaviour {

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
