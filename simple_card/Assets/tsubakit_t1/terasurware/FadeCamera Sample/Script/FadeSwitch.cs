using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FadeCamera))]
public class FadeSwitch : MonoBehaviour {

	[Range(0.0f, 5f)]
	public float time = 1;

	void OnEnable()
	{
		GetComponent<FadeCamera>().FadeIn( time , Finished);
	}

	void OnDisable()
	{
		GetComponent<FadeCamera>().FadeOut( time , Finished);
	}

	void Finished()
	{
		GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

		if( gameController != null )
			gameController.SendMessage("FadeFinished", SendMessageOptions.DontRequireReceiver);
	}

	static FadeSwitch Instance
	{
		get{
			FadeSwitch fade = FadeCamera.Instance.GetComponent<FadeSwitch>();
			if( fade == null)
				fade = FadeCamera.Instance.gameObject.AddComponent<FadeSwitch>();
			return fade;
		}
	}

	public static float FadeTime
	{
		get{
			return Instance.time;
		}
		set{
			Instance.time = value;
		}
	}

	public static bool IsFadeOut
	{
		get{
			return Instance.enabled;
		}

		set{
			Instance.enabled = value;
		}
	}
}
