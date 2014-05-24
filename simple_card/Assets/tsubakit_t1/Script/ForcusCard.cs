using UnityEngine;
using System.Collections;

public class ForcusCard : SingletonMonoBehaviour<ForcusCard>
{
	public delegate void TapObject (GameObject forcus);

	/// <summary>
	/// Occurs when forcus object e.
	/// </summary>
	public event TapObject forcusObjectE = null;

	/// <summary>
	/// Occurs when release object.
	/// </summary>
	public event TapObject releaseObjectE = null;

	/// <summary>
	/// forcus object
	/// </summary>
	/// <value>The forcus object.</value>
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
		// forcus object
		if (Input.GetMouseButtonDown (0)) {

			var tapPosition = _mainCamera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * -_mainCamera.transform.position.z);

			var collider = Physics2D.OverlapCircle (tapPosition, 0.1f);
			if (collider != null) {
				forcusObject = collider.gameObject;
				if (forcusObjectE != null) {
					forcusObjectE (forcusObject);
				}
			}
		}

		// release object
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
