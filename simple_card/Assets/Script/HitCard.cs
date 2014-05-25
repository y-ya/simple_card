using UnityEngine;
using System.Collections;

public class HitCard : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Card selfCardState = GetComponent<Card>();
		Card hitCardState = other.GetComponent<Card>();



		if( hitCardState == null || selfCardState.target != Card.Target.PlayerObject)
		{
			return;
		}

		if( !selfCardState.GetComponent<Card> ().isTouch )
		{
			return;
		}
		if( hitCardState.mark  == selfCardState.mark ||
		    hitCardState.number == selfCardState.number)
		{
			//TODO
			other.gameObject.rigidbody2D.AddForce(new Vector2(0f,1200f));
			if( 1 == Random.Range(0,2) ){
				other.gameObject.rigidbody2D.AddTorque( Random.Range(500f,10000f));
			}else{
				other.gameObject.rigidbody2D.AddTorque( Random.Range(-10000f,-500f));
			}
			other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			//Destroy ( other.gameObject );
			GameController.Instance.score += 1;
			Destroy ( gameObject );
			GameManager.combo.combo_counter += 1;

			GameManager.combo.current_combo_timer = GameManager.combo.combo_timer;
			SoundManager.Instance.PlaySE(0);
		}
	}

}
