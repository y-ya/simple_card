using UnityEngine;
using System.Collections;

public class ResultBarController : MonoBehaviour {

	public Transform[] barList;

	private GameController gameController;

	float rate = 0 ;

	public TextMesh text;

	void Start () 
	{
		gameController = GameController.Instance;
		gameController.UpdateScore();

		int max = Mathf.Max( gameController.oldScoreQueue.ToArray());
		max = max == 0 ? 1 : max;
		rate = (float)14 / max;


		foreach( var bar in barList)
		{
			bar.localScale = new Vector3(0.45f, 0.0f, 0.45f);
		}

		text.text = gameController.score.ToString();
	}
	
	void Update () {

		int i=0;
		foreach(var height in gameController.oldScoreQueue)
		{
			if( i < GameController.max)
			{
				var localScale = barList[i].transform.localScale;
				float y = localScale.y ;
				localScale.y = Mathf.Lerp(y, height * rate, 0.2f);
				
				barList[i].transform.localScale = localScale;
			}
			i++;
		}

		if (Time.timeSinceLevelLoad > 3 && Input.GetMouseButtonUp(0))
		{
			LoadLevel(1);
		}
	}
	void LoadLevel(int nextLevel)
	{
		FadeCamera.Instance.UpdateMaskTexture( Resources.Load<Texture>("test1"));
		FadeCamera.Instance.FadeOut(0.3f, ()=>
		                            {
			Application.LoadLevel (nextLevel);
			FadeCamera.Instance.UpdateMaskTexture( Resources.Load<Texture>("test2"));
			FadeCamera.Instance.FadeIn(0.3f, null);
		});
	}
}
