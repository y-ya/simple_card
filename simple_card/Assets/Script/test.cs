using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreateCard card = new CreateCard ();
		GameObject obj = card.findCardOfGameObject ();
		Instantiate (obj);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
