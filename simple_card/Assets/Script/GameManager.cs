using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager manager;
	public int end_count   = 10;
	public float play_time = 10f;
	public bool isTimer    = true;
	// Use this for initialization
	void Start () {
		manager = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimer) {
			play_time -= Time.deltaTime;
			if (play_time <= 0) {
				enabled = false;
				setScoreText();
				LoadLevel(Application.loadedLevelName);
			}
		} else {
			if(end_count <= 0){
				enabled = false;
				setScoreText();
				LoadLevel(Application.loadedLevelName);
			}
		}
	}

	void LoadLevel(string levelName)
	{
		FadeCamera.Instance.UpdateMaskTexture( Resources.Load<Texture>("test1"));
		FadeCamera.Instance.FadeOut(0.3f, ()=>
		                            {
			Application.LoadLevel (Application.loadedLevelName);
			FadeCamera.Instance.UpdateMaskTexture( Resources.Load<Texture>("test2"));
			FadeCamera.Instance.FadeIn(0.3f, null);
		});
	}
	private GameObject score;
	public void setScoreText(){
		if(null == score){
			score = (GameObject)Instantiate (Resources.Load<GameObject>("ScoreText"));

			TextMesh tm = score.GetComponent<TextMesh>();
			tm.text = "Score : "+ GameController.Instance.score;
		}
	}
}
