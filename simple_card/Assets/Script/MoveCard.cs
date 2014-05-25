using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveCard : MonoBehaviour {

	public Vector3 direction;

	public void SetDirection(Vector2 newDirection)
	{
		direction = newDirection;
	}

	void Start () {
		rigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
	}

	void Update () {
		transform.position += direction * Time.deltaTime;
	}
}
