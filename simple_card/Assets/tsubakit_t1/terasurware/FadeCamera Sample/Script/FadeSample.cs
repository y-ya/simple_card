using UnityEngine;
using System.Collections;

namespace FCamera
{
	public class FadeSample : MonoBehaviour
	{
		public Texture2D texture;

		public Texture2D startMask, endMask;

		[Range(0, 3)]
		public float fadeinTime = 0.4f, fadeoutTime = 1.4f;

		int nextScene = 0;

		void Update ()
		{
			if( Input.GetMouseButtonDown(0)){
				LoadLevel();
			}
		}

		void LoadLevel()
		{
			FadeCamera.Instance.UpdateTexture(texture);
			FadeCamera.Instance.UpdateMaskTexture(startMask);
			FadeCamera.Instance.FadeOut ( fadeinTime, () =>
			{
				Application.LoadLevel (nextScene);
				FadeCamera.Instance.UpdateMaskTexture(endMask);
				FadeCamera.Instance.FadeIn (fadeoutTime , null);
			});
		}
	}
}