using UnityEngine;
using System.Collections;

public class InisializeCard : MonoBehaviour {

	public string mark;
	public int no;

	void Start () {

		var card = GetComponent<Card>();
	
		card.mark = mark;
		card.number = no;

		Debug.Log(card.mark + "/" + card.number);
	}
}
