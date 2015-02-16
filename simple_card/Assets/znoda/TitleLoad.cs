using UnityEngine;
using System.Collections;

public class TitleLoad : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("Demo");
		}
	}

//	void OnGUI() {
//		if (GUI.Button (new Rect (Screen.width / 2 - 100, 200, 200, 30), "Game Start"))
//		{
//			Application.LoadLevel("Demo");
//		}
//	}
}
