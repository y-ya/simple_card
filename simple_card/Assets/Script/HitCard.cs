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
			int base_point = 0;
			if(hitCardState.mark  == selfCardState.mark &&
			   hitCardState.number == selfCardState.number){
				base_point = 2;
				GameObject obj = Instantiate(GameManager.greatEffect) as GameObject;
				obj.GetComponent<TextMesh>().text = "えくせれんと!!";
			}else if(hitCardState.number == selfCardState.number){
				base_point = 1;
				GameObject obj = Instantiate(GameManager.greatEffect) as GameObject;
				obj.GetComponent<TextMesh>().text = "ぐれーと!";
			}
			//TODO
			other.gameObject.rigidbody2D.AddForce(new Vector2(0f,1200f));
			if( 1 == Random.Range(0,2) ){
				other.gameObject.rigidbody2D.AddTorque( Random.Range(500f,10000f));
			}else{
				other.gameObject.rigidbody2D.AddTorque( Random.Range(-10000f,-500f));
			}
			other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			//Destroy ( other.gameObject );
			GameManager.combo.combo_counter += 1;
			GameController.Instance.score += GameManager.combo.combo_counter + base_point;
			Destroy ( gameObject );
			if( GameManager.combo.combo_counter >= 3 ){
				GameManager.mainCamera.Shake(GameManager.combo.combo_counter/10.0f);
			}
			GameManager.combo.current_combo_timer = GameManager.combo.combo_timer;
			SoundManager.Instance.PlaySE(0);
			//SoundManager.Instance.PlaySE(GameManager.combo.combo_counter%8 + 1);
		}
	}

}
