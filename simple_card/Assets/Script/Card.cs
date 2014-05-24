using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	
	private int    __number;
	private string __mark;
	private int    __target;
	public int    number{ get; set; }
	public string mark  { get; set; }
	/// <summary>
	/// 0: player obj 1: fall obj
	/// </summary>
	/// <value>The target.</value>
	public int    target { get; set; }
}
