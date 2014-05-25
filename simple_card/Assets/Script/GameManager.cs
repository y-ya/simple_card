using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager manager;
	public static Combo combo;
	public static GameObject greatEffect;
	public int end_count   = 10;
	public float play_time = 10f;
	public bool isTimer    = true;
	public Object[] particleSystems;
	public float pitch = 0.0f;
	public static CameraShake mainCamera;
	// Use this for initialization
	void Awake(){
		Application.targetFrameRate = 60;
		greatEffect = Resources.Load<GameObject>("prefab/GreatEffect");
		mainCamera = Camera.main.gameObject.GetComponent<CameraShake>();  
	}
	void Start () {
		manager = this;
		GameObject obj = GameObject.Find ("Combo") as GameObject;
		combo = obj.GetComponent<Combo> ();

		GameController.Instance.score = 0;
		Music.CurrentSource.source.pitch = 1.0f;
		Music.CurrentSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimer) {
			play_time -= Time.deltaTime;
			if (play_time <= 0) {
				enabled = false;
				setScoreText();
				LoadLevel(2);

				// BGM Reset.
				Music.CurrentSource.source.pitch = 1.0f;
			}
		} else {
			if(end_count <= 0){
				enabled = false;
				setScoreText();
				LoadLevel(2);
			}
		}

		if( combo.combo_counter > 0 && isTimer ) {
			Music.CurrentSource.source.pitch = (float)(1+combo.combo_counter*0.1f);
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
	private GameObject score;
	public void setScoreText(){
		if(null == score){
			score = (GameObject)Instantiate (Resources.Load<GameObject>("ScoreText"));

			TextMesh tm = score.GetComponent<TextMesh>();
			tm.text = "Score : "+ GameController.Instance.score;
		}
	}
}
