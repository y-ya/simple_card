using UnityEngine;
using System.Collections;

public class ThrowCard : MonoBehaviour {

	private Vector3 throwDirection;

	private GameObject forcus;


	public float power = 24;

	void Start () {

		var swipeCheck = GetComponent<TouchSwipeCheck>();
		var forcusCard = GetComponent<ForcusCard>();

		swipeCheck.swipeE += (direction) => 
		{
			throwDirection = direction;
			if( forcusCard.lastForcusObject != null)
			{
				var moveCard = forcusCard.lastForcusObject.GetComponent<MoveCard>();
				moveCard.SetDirection( throwDirection * power);
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
}
