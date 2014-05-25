using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	
	private int    __number;
	private string __mark;
	private int    __target;
	private bool   __isTouch;
	public int    number;
	public string mark  ;

	public Sprite cardImage;

	public bool isTouch = false;

	public TextMesh text;

	public enum Target 
	{
		PlayerObject, 
		FallObject,
	}

	/// <summary>
	/// 0: player obj 1: fall obj
	/// </summary>
	/// <value>The target.</value>
	public Target    target;

}
