using UnityEngine;
using System.Collections;

public class FadeGUI : MonoBehaviour {

	public Texture maskTexture;

	void Start()
	{
		FadeCamera.Instance.UpdateMaskTexture(maskTexture);
	}

	void OnGUI()
	{
		if( FadeCamera.Instance.fading == false )
		{
			if( GUILayout.Button("switch"))
			{
				FadeSwitch.IsFadeOut = !FadeSwitch.IsFadeOut;
			}
			FadeSwitch.FadeTime = GUILayout.HorizontalSlider(FadeSwitch.FadeTime, 0, 5, GUILayout.Width(300));
			GUILayout.Label("fade time:" + FadeSwitch.FadeTime);
		}
	}

	void FadeFinished()
	{
		Debug.Log("finished");
	}
}
