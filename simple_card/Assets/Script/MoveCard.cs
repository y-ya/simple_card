using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveCard : MonoBehaviour {

	public Vector3 direction;
	[Range(0.1f, 100)]
	public float speed = 30;

	private Vector3 realDirection;

	public void SetDirection(Vector2 newDirection)
	{
		direction = newDirection.normalized;
		realDirection = direction * speed;
	}

	void Start () {
		rigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
		realDirection = direction.normalized * speed;
	}

	void Update () {


		transform.position += realDirection * Time.deltaTime;
	}
}
