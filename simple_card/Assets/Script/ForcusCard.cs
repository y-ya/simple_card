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
	public GameObject lastForcusObject { get; private set; }

	protected Camera _mainCamera; 

	void Start ()
	{
		_mainCamera = Camera.main;
	}

	public bool IsForcus{get; private set;}

	void Update ()
	{
		// forcus object
		if (Input.GetMouseButtonDown (0)) {

			var tapPosition = _mainCamera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * -_mainCamera.transform.position.z);

			var collider = Physics2D.OverlapCircle (tapPosition, 0.1f);
			if (collider != null) {
				Card card = collider.GetComponent<Card>();
				Debug.Log(card.isTouch);
				if( card.target != Card.Target.PlayerObject){
					return;
				}
				lastForcusObject = collider.gameObject;
				card.isTouch = true;
				IsForcus = true;
				if (forcusObjectE != null) {
					forcusObjectE (lastForcusObject);
				}
			}
		}

		// release object
		if (Input.GetMouseButtonUp (0)) {
			IsForcus = false;
			if (lastForcusObject != null && releaseObjectE != null) {
				releaseObjectE (lastForcusObject);
			}
		}
	}

	void OnDestroy ()
	{
		forcusObjectE = null;
	}


}
