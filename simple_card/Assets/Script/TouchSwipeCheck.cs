using UnityEngine;
using System.Collections;

public class TouchSwipeCheck : MonoBehaviour {

	// PC用
	#if UNITY_STANDALONE_OSX
	viod Start() {
		GUI.Button(new Rect(30,30,200,80), "モバイル用のクラスです")
	}
	#endif
	// モバイル用
	#if UNITY_ANDROID || UNITY_IPHONE
	private Vector2 touchDeltaPosition;
	private Vector2 normalizeDeltePositon;

	void Update ()
	{

		if (Input.touchCount > 0) {	
			Touch myTouch = Input.GetTouch(0);

			switch (myTouch.phase) {
			case TouchPhase.Began:
//				Debug.Log ("touchPhase.Began");
				break;

			case TouchPhase.Moved:
//				Debug.Log ("touchPhase.Moved");

				// デルタ（正規化）する
				touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//				Debug.Log("touchDeltaPosition:" + touchDeltaPosition);
				normalizeDeltePositon = touchDeltaPosition.normalized;
				Debug.Log("touchDeltaPosition normalized:" + normalizeDeltePositon);

				// 絶対値に変換する
				float mathabsX = Mathf.Abs(normalizeDeltePositon.x);
				float mathabsY = Mathf.Abs(normalizeDeltePositon.y);
				Debug.Log("mathabsX:" + mathabsX + " mathabsY:" + mathabsY);

				if (mathabsX < mathabsY) {
					if (touchDeltaPosition.x < 0f && touchDeltaPosition.y >= 0f) {
						Debug.Log("上スワイプ!!!");
					}
	//				else if (touchDeltaPosition.x < 0f && touchDeltaPosition.y < 0f) {
	//					Debug.Log("下スワイプ!!!");
	//				}
				}
				if (mathabsX > mathabsY) {
					if (touchDeltaPosition.x < 0f && touchDeltaPosition.y >= 0f) {
						Debug.Log("左スワイプ!!!");
					}
	//				else if (touchDeltaPosition.x >= 0f && touchDeltaPosition.y < 0f) {
	//					Debug.Log("右スワイプ!!!");
	//				}
				}

				break;
			// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
//				Debug.Log ("touchPhase.Ended");
				break;
			}
		}
	}
	#endif
}

