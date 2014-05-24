using UnityEngine;
using System.Collections;

public class SelectCardTest : MonoBehaviour {

	ForcusCard selectCard;

	void Awake ()
	{
		selectCard = GetComponent<ForcusCard>();

		selectCard.forcusObjectE += (forcus) => 
		{
			Debug.Log("forcus object" + forcus.name);
		};
		selectCard.releaseObjectE += (forcus) => 
		{
			Debug.Log("release object" + forcus.name);
		};
	}
	
	void OnGUI ()
	{
		if (selectCard.forcusObject != null) {
			GUILayout.Label (selectCard.forcusObject.name);
		}
	}
}
