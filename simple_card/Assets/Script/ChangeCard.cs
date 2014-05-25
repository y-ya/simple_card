using UnityEngine;
using System.Collections;

public class ChangeCard : MonoBehaviour {

	private GameObject hand;
	private GameObject set1;
	private GameObject card1;
	private GameObject set2;
	private GameObject card2;
	private GameObject set3;
	private GameObject card3;
	private GameObject set4;
	private GameObject card4;

	private CreateCard card;
	// Use this for initialization
	void Start () {
		card = new CreateCard();

		hand  = GameObject.Find("hands");
		set1  = hand.gameObject.transform.FindChild("SetCardPosition1").gameObject;
		card1 = Instantiate(card.findCardOfGameObject(), set1.transform.position, Quaternion.identity) as GameObject;
		set2  = hand.gameObject.transform.FindChild("SetCardPosition2").gameObject;
		card2 = Instantiate(card.findCardOfGameObject(), set2.transform.position, Quaternion.identity) as GameObject;
		set3  = hand.gameObject.transform.FindChild("SetCardPosition3").gameObject;
		card3 = Instantiate(card.findCardOfGameObject(), set3.transform.position, Quaternion.identity) as GameObject;
		set4  = hand.gameObject.transform.FindChild("SetCardPosition4").gameObject;
		card4 = Instantiate(card.findCardOfGameObject(), set4.transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(null == card1){
			card1 = Instantiate(card.findCardOfGameObject(), set1.transform.position, Quaternion.identity) as GameObject;
		}
		if(null == card2){
			card2 = Instantiate(card.findCardOfGameObject(), set2.transform.position, Quaternion.identity) as GameObject;
		}
		if(null == card3){
			card3 = Instantiate(card.findCardOfGameObject(), set3.transform.position, Quaternion.identity) as GameObject;
		}
		if(null == card4){
			card4 = Instantiate(card.findCardOfGameObject(), set4.transform.position, Quaternion.identity) as GameObject;
		}
	}
}
