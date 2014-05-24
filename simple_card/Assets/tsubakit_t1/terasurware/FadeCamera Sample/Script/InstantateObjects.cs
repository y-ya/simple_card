using UnityEngine;
using System.Collections;

public class InstantateObjects : MonoBehaviour {

	[Range(0.1f, 1f)]
	public float interval = 1;

	public GameObject prefab;

	void Awake()
	{
		prefab.SetActive(false);
	}

	IEnumerator Start()
	{
		while(true)
		{
			var obj = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
			obj.rigidbody.AddTorque(Vector3.forward * 1000);
			obj.SetActive(true);
			Destroy (obj, 30);
			Destroy (obj.constantForce, 1);

			yield return new WaitForSeconds(interval);
		}
	}
}
