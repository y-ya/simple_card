using UnityEngine;
using System;
using System.Collections;

public class TouchSwipeCheck : MonoBehaviour {

	public delegate void ThrowEvent(Vector3 direction);
	public delegate void DragEvent(Vector3 dragWorldPosition);
	
	public event Action leftSwpeE = null;
	public event ThrowEvent swipeE = null;
	public event DragEvent dragging = null;

	public Vector3 preMousePositionPoition = Vector3.zero;

	/*
	private float swipeStartTime = 0;
	private Vector3 startSwipePosition = Vector3.zero;
	*/

	void OnDestroy()
	{
		leftSwpeE = null;
		swipeE = null;
	}

	void Update ()
	{
		Vector3 mousePosition = Input.mousePosition;

		if( Input.GetMouseButtonDown(0))
		{
			preMousePositionPoition = mousePosition;
			//swipeStartTime = Time.timeSinceLevelLoad;
			//startSwipePosition = Input.mousePosition;
		}

		if( Input.GetMouseButtonUp(0) )
		{
			//float swipedTime = Time.timeSinceLevelLoad - swipeStartTime;

			if( swipeE != null )
			{
				//Vector3 diffSwipe = (preMousePositionPoition - startSwipePosition) / swipedTime;
				Vector3 diffMousePosition = mousePosition - preMousePositionPoition;

				if( swipeE != null){
					swipeE( diffMousePosition );
				}
			}
		}

		if( Input.GetMouseButton(0))
		{
			Vector3 diffMousePosition = mousePosition - preMousePositionPoition;
			float swipeAngle = Vector2.Angle( Vector3.up, diffMousePosition);

			// swipe left
			if( swipeAngle > 80 && swipeAngle < 110 && diffMousePosition.x < 0 )
			{
				if( leftSwpeE != null){ leftSwpeE(); }
			}

			if( dragging != null)
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition - (Camera.main.transform.position.z * transform.forward));
				dragging(worldPos);
			}

			preMousePositionPoition = mousePosition;

		}else{
			preMousePositionPoition = Vector3.zero;
		}
	}
}

