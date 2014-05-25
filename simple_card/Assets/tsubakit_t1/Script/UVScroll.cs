using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour {

	public Vector2 direction;
	Vector2 currentOffset;

	Material mat;

	void Start()
	{
		mat = renderer.material;
	}

	void Update () 
	{
		currentOffset += direction * Time.deltaTime;
		mat.SetTextureOffset("_MainTex", currentOffset);
	}
}
