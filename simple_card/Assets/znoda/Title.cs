using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - 100, 200, 200, 30), "Game Start"))
		{
			enabled = false;
			var fadeCamera = FadeCamera.Instance;
			fadeCamera.UpdateMaskTexture(Resources.Load<Texture>("test"));
			fadeCamera.FadeOut( 3,  ()=>
			{
				Application.LoadLevel("Demo");
				fadeCamera.UpdateMaskTexture(Resources.Load<Texture>("test2"));
				fadeCamera.FadeIn(0.3f, null);
			});

		}
	}
}
