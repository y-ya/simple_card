using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager manager;
	public static Combo combo;
	public int end_count   = 10;
	public float play_time = 10f;
	public bool isTimer    = true;
	public Object[] particleSystems;
	public float pitch = 0.0f;

	// Use this for initialization
	void Awake(){
		Application.targetFrameRate = 60;
		particleSystems = Resources.LoadAll("Explosions", typeof(GameObject));
	}
	void Start () {
		manager = this;
		GameObject obj = GameObject.Find ("Combo") as GameObject;
		combo = obj.GetComponent<Combo> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimer) {
			play_time -= Time.deltaTime;
			if (play_time <= 0) {
				enabled = false;
				setScoreText();
				LoadLevel(Application.loadedLevelName);

				// BGM Reset.
				Music.CurrentSource.source.pitch = 1.0f;
			}
		} else {
			if(end_count <= 0){
				enabled = false;
				setScoreText();
				LoadLevel(Application.loadedLevelName);
			}
		}

		if( combo.combo_counter > 0 && isTimer ) {
			Music.CurrentSource.source.pitch = (float)(1+combo.combo_counter*0.1f);
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
