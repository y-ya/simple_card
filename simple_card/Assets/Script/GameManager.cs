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
				Application.LoadLevel (Application.loadedLevelName);
			}
		} else {
			if(end_count <= 0){
				Application.LoadLevel (Application.loadedLevelName);
			}
		}
	}

}
