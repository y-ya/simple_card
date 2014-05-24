using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	void Update () {
		if( Input.GetKeyDown(KeyCode.A) == true ) {
			// Torigger
			Debug.Log( "A!" );
			//Singleton<SoundPlayer>.instance.playSE("se001");
			SoundManager.Instance.PlaySE(0);
			//SoundManager.Instance.PlayBGM(0);
		}
	}
}
