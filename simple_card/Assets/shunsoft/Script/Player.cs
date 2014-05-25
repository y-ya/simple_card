using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	void Update () {
		// music sync UI
		guiText.text = "Just: " + Music.Just.ToString();
		if( Music.IsJustChangedBar() ) {
			guiText.material.color = Music.Just.bar % 2 == 0 ? Color.white : Color.yellow;
		}
		int mtBeat = Music.mtBeat;
		guiText.transform.position = new Vector3(0.5f, 0.5f + 0.02f * (float)(mtBeat - Music.MusicalTime % mtBeat)/mtBeat, 0);

		// easy quantize play
		if( Input.GetMouseButtonDown(0) ) {
			Music.QuantizePlay( new Music.SoundCue(audio) );
			
		}

		// you can pause
		if( Input.GetMouseButtonDown(1) ) {
			if( Music.IsPlaying() ) {
				Music.Pause();
			} else {
				Music.Resume();
			}
		}

#if !ADX
		if( Input.GetKeyDown(KeyCode.A) == true ) {
			// Torigger
			Music.CurrentSource.source.pitch = Music.CurrentSource.source.pitch > 1.0f ? 1.0f : 2.0f;
		}
#endif
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
