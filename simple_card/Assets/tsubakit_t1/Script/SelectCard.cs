using UnityEngine;
using System.Collections;

public class SelectCard : MonoBehaviour
{
	public delegate void TapObject (GameObject forcus);


	public event TapObject forcusObjectE = null;
	public event TapObject releaseObjectE = null;
	public GameObject forcusObject { get; private set; }
	public bool isSelected {
		get {
			return forcusObject != null;
		}
	}

	protected Camera _mainCamera; 

	void Start ()
	{
		_mainCamera = Camera.main;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {

			//var ray = _mainCamera.ScreenPointToRay (Input.mousePosition);
			var tapPosition = _mainCamera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * -_mainCamera.transform.position.z);

			var collider = Physics2D.OverlapCircle (tapPosition, 0.1f);
			if (collider != null) {
				forcusObject = collider.gameObject;
				if (forcusObjectE != null) {
					forcusObjectE (forcusObject);
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (forcusObject != null && releaseObjectE != null) {
				releaseObjectE (forcusObject);
			}

			forcusObject = null;
		}
	}

	void OnDestroy ()
	{
		forcusObjectE = null;
	}


}
