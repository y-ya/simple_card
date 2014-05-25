using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	private TextMesh tm;
	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
	}
	private int current_score = 0;
	// Update is called once per frame
	void Update () {
		if(GameController.Instance.score != current_score){
			tm.text = "すこあ:"+GameController.Instance.score;
			current_score = GameController.Instance.score;
		}
	}
}
