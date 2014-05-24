using UnityEngine;
using System.Collections;

public class HitCard : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Card selfCardState = GetComponent<Card>();
		Card hitCardState = other.GetComponent<Card>();

		if( hitCardState == null)
		{
			return;
		}

		if( hitCardState.mark  == selfCardState.mark ||
		    hitCardState.number == selfCardState.number)
		{
			Destroy ( other.gameObject );
			GameController.Instance.score += 1;
			
			Destroy ( gameObject );
		}
	}
}
