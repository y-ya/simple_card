using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Vector3 originPosition;
	float shake_decay = 0.002f;  
	float shake_intensity;  
	float coef_shake_intensity = 0.3f;  

	// Use this for initialization
	void Start () {

	}
	
	void Update(){  
		if(shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;  
			shake_intensity -= (GameManager.combo.combo_counter > 0) ? shake_decay : 1000f;
		}  
	} 
	public void Shake(float _shake_intensity){  
		originPosition = transform.position;  
		shake_intensity = _shake_intensity;  
	}  
}
