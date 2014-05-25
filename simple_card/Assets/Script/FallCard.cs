using UnityEngine;
using System.Collections;

public class FallCard : MonoBehaviour 
{
	public float createTime = 5f;
	private float current_timer;
	private CreateCard createCard = new CreateCard();

	public Vector3 topLeft, bottomRight;

	void Start () 
	{
		current_timer = createTime;
	}

	void Update () 
	{
		current_timer -= Time.deltaTime;
		if (current_timer <= 0.0f) {
			current_timer = createTime - GameManager.combo.combo_counter;
			if(current_timer <= 1.0f){
				current_timer = 1.0f;
			}
			GameObject obj = Instantiate(
				createCard.findCardOfGameObject(Card.Target.FallObject, false), 
				new Vector3(Random.Range(-5,5), 5, 0), 
				Quaternion.identity) as GameObject;

			Rigidbody2D r = obj.GetComponent<Rigidbody2D> ();
			r.isKinematic = false;



			float power = Random.Range(100, 500);
			Vector3 targetPoint = new Vector3( 
			                          Random.Range(bottomRight.x, topLeft.x), 
			                          Random.Range(bottomRight.y, topLeft.y), 0 );


			Vector3 diff = ( targetPoint - obj.transform.position ).normalized;

			r.AddForce(diff * power);
		}
	}

#if UNITY_EDITOR
	void OnDrawGizmosSelected ()
	{
		Vector3[] vectors = 
		{
			new Vector3(topLeft.x, topLeft.y),
			new Vector3(topLeft.x, bottomRight.y),
			new Vector3(bottomRight.x, bottomRight.y),
			new Vector3(bottomRight.x, topLeft.y)
		};


		UnityEditor.Handles.DrawSolidRectangleWithOutline( vectors,
		new Color(1,1,1,0),
		Color.white
		);
	}
#endif
}
