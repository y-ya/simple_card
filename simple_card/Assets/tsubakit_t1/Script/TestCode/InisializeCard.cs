using UnityEngine;
using System.Collections;

public class InisializeCard : MonoBehaviour {

	public string mark;
	public int no;

	public bool update = true;

	void Start () {

		var card = GetComponent<Card>();
		if( update == false){
			Debug.Log(card.mark + "/" + card.number);
			mark = card.mark ;
			no = card.number;
		}else
		{
			card.mark = mark;
			card.number = no;

		}

	}
}
