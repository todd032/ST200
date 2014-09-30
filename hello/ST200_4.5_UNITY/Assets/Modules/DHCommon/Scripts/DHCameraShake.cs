using UnityEngine;
using System.Collections;

public class DHCameraShake : MonoBehaviour {
	
	private Transform _thisTransform ;
	
	public bool isShaking = true ;
	
	private Vector3 initPosition ;
	private Quaternion initRotation ;
	
	private Vector3 originPosition ;
//	private Quaternion originRotation ; //Warning never used..
	
	private float shake_decay = 0.04f ;
	private float shake_intensity = 0.02f ;
	
	private void Awake(){
		
		_thisTransform = Camera.main.transform ;
		
		//initPosition = _thisTransform.position;
		//initRotation = _thisTransform.rotation;
		
		//initPosition = new Vector3(0 , 0 , -10);
//		initRotation =  new Vector3(0 , 0 , 0);
	}
	
	private void Start(){
	}

	private void Update () {
		
		if(!isShaking) return ;
		
		if(shake_intensity > 0){
    		_thisTransform.position = originPosition + Random.insideUnitSphere * shake_intensity;
    		/*_thisTransform.rotation = new Quaternion(originRotation.x + Random.Range(-shake_intensity, shake_intensity)*.2f,
                              					originRotation.y + Random.Range(-shake_intensity, shake_intensity)*.2f,
                              					originRotation.z + Random.Range(-shake_intensity, shake_intensity)*.2f,
                              					originRotation.w + Random.Range(-shake_intensity, shake_intensity)*.2f);
			*/ 
   			shake_intensity -= shake_decay;
		
		}else if (!isShaking){

   			//_thisTransform.position = initPosition ;
			//_thisTransform.rotation = initRotation ;
			isShaking = false; 
		}

	}

	public void DoCameraShake(){
		
		originPosition = transform.position;
//		originRotation = initRotation; //Warning never used..

		shake_intensity = 0.04f;
		shake_decay = 0.02f;
		isShaking = true;
	}
	
	public void DoCameraShake(float intensityValue, float decayValue){
		
		originPosition = transform.position;
//		originRotation = initRotation; //Warning never used..

		shake_intensity = intensityValue;
		shake_decay = decayValue;
		isShaking = true;
	}
}
