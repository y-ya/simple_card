using UnityEngine;
using System.Collections;

public class TitleLoad : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
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
