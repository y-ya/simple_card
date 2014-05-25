using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	void Update () {
		if( Input.GetKeyDown(KeyCode.A) == true ) {
			// Torigger
			Debug.Log( "A!" );
		}
	}

	void OnGUI() {
		if( GUI.Button(new Rect(10, 20, 120, 80), "BGMPlay") ) {
			SoundManager.Instance.PlayBGM(0);
		}
		if( GUI.Button(new Rect(10+10+120, 20, 120, 80), "BGMStop") ) {
			SoundManager.Instance.StopBGM();
		}
		if( GUI.Button(new Rect(10+(10+120)*2, 20, 120, 80), "SEPlay") ) {
			SoundManager.Instance.PlaySE(0);
		}
	}
}
