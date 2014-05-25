using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - 100, 200, 200, 30), "Game Start"))
		{
			Application.LoadLevel("Demo");
		}
	}
}
