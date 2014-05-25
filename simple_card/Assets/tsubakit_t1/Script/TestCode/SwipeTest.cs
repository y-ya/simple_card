using UnityEngine;
using System.Collections;

public class SwipeTest : MonoBehaviour {

	private Vector3 throwDirection;

	private GameObject forcus;

	void Start () {

		var swipeCheck = GetComponent<TouchSwipeCheck>();
		var forcusCard = GetComponent<ForcusCard>();

		swipeCheck.leftSwpeE += () => 
		{
			Debug.Log("reload");
		};

		swipeCheck.swipeE += (direction) => 
		{
			throwDirection = direction;
			if( forcusCard.lastForcusObject != null)
			{
				var moveCard = forcusCard.lastForcusObject.GetComponent<MoveCard>();
				moveCard.SetDirection( throwDirection );
			}
		};

		swipeCheck.dragging += (dragWorldPosition) =>  
		{
			if( forcusCard.lastForcusObject != null)
			{
				forcusCard.lastForcusObject.transform.position = dragWorldPosition;
			}
		};
	}

	void Update()
	{
		Debug.DrawRay(Vector3.zero, throwDirection, Color.red);
	}
	void OnGUI()
	{
		GUILayout.Label(throwDirection.ToString());
	}
}
