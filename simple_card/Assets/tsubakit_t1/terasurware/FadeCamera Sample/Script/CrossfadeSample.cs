
using UnityEngine;
using System.Collections;

namespace FCamera
{
	public class CrossfadeSample : MonoBehaviour
	{
		private Texture2D crossfadeTexture;
		public Texture maskTexture ;
		public float fadeoutTime = 1.4f;
		int nextScene = 0;

		void Start ()
		{
			FadeCamera.Instance.UpdateMaskTexture (maskTexture);
		}

		void Update ()
		{
			if (Input.GetMouseButtonDown (0)) {
				LoadLevel (nextScene);
			}
		}

		void LoadLevel (int nextLevel)
		{
			StartCoroutine (CaptureScreen (() =>
			{
				FadeCamera.Instance.UpdateTexture (crossfadeTexture);
				Application.LoadLevel (nextLevel);
				FadeCamera.Instance.FadeIn (fadeoutTime, () => 
				{
					Destroy (crossfadeTexture);
				});
			}));
		}

		IEnumerator CaptureScreen (System.Action action)
		{
			yield return new WaitForEndOfFrame ();
			crossfadeTexture = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);

			crossfadeTexture.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
			crossfadeTexture.Apply ();

			action ();
		}
	}
}