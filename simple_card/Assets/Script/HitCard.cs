using UnityEngine;
using System.Collections;

public class HitCard : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy ( other.gameObject );
		GameController.Instance.score += 1;

		Destroy ( gameObject );

		// TODO: カードの持つ種類が一致していたら消さない
	}
}
