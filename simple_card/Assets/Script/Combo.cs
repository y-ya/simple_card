using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {

	private string combo = "{0}こんぼ!!";
	public int   combo_counter = 2;
	public float current_combo_timer = 0;
	public float combo_timer = 2f;
	private TextMesh tm;
	// Use this for initialization
	void Start () {
		current_combo_timer = combo_timer;
		tm = gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (combo_counter > 0) {
			current_combo_timer -= Time.deltaTime;
			if(current_combo_timer <= 0) combo_counter = 0;
			tm.text = string.Format (combo, combo_counter.ToString());
		} else {
			current_combo_timer = combo_timer;
			tm.text = "";
		}
	}
}
