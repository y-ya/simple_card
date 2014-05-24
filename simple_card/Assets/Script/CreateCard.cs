using UnityEngine;
using System.Collections;

/*public class CreateCard : MonoBehaviour {
}*/
public class CreateCard {

	public int max_number = 9;
	private readonly string   resource_path = "card/{0}";
	private readonly string[] card_type     = {"c","s","d","h"};

	/*public Texture2D findCardOfTexture2D( int number = 0 , string mark = null ){
		if(string.IsNullOrEmpty(mark))
			mark = card_type[Random.Range(0,4)];
		if(number <= 0)
			number = Random.Range(1,14);
		string file_name = makeFileString (number, mark);
		return Resources.Load<Texture2D> ( file_name );
	}*/
	public GameObject findCardOfGameObject(Card.Target target = Card.Target.FallObject, bool set_kinematic = true, int number = 0 , string mark = null ){
		if(string.IsNullOrEmpty(mark))
			mark = card_type[Random.Range(0,4)];
		if(number <= 0)
			number = Random.Range(1,max_number);
		string file_name = makeFileString (number, mark);

		GameObject obj = Resources.Load<GameObject> ( "card" );
		Card card = obj.GetComponent<Card> ();
		card.number = number;
		card.mark   = mark;
		card.target = target;
		SpriteRenderer sr = obj.GetComponent<SpriteRenderer> ();
		sr.sprite = Resources.Load<Sprite>(file_name);
		return obj;
	}

	private string makeFileString( int number, string mark ){
		return string.Format (resource_path, mark + number.ToString ("00"));
	}
}
