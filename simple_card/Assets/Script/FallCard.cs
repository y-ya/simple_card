using UnityEngine;
using System.Collections;

public class FallCard : MonoBehaviour {


	public float createTime = 5f;
	private float current_timer;
	private CreateCard createCard = new CreateCard();
	// Use this for initialization
	void Start () {
		current_timer = createTime;
	}


	// Update is called once per frame
	void Update () {
		current_timer -= Time.deltaTime;
		if (current_timer <= 0.0f) {
			current_timer = createTime;
			GameObject obj = Instantiate(createCard.findCardOfGameObject(1), new Vector3(Random.Range(-5,5), 5, 0), Quaternion.identity) as GameObject;
			setRigidBody(obj);
		}
	}

	private void setRigidBody(GameObject obj){
		Rigidbody2D r = obj.AddComponent<Rigidbody2D> ();
		r.gravityScale = Random.Range (0.1f, 0.9f);

	}
}
