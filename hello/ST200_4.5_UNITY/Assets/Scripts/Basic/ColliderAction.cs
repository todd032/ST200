using UnityEngine;
using System.Collections;

public class ColliderAction : MonoBehaviour {
	
	
	public delegate void DelegateParam1(Collider col);
	private  DelegateParam1 onTriggerEnterEx;
	
	public event DelegateParam1 OnTriggerEnterEx {
        add{
            if (onTriggerEnterEx == null)
                onTriggerEnterEx += value;
        }
        remove{
            onTriggerEnterEx -= value;
        }
    }
		
	void OnTriggerEnter (Collider col){

		if ( onTriggerEnterEx != null) {
			 onTriggerEnterEx(col);
		}
		
//		if ( col.tag =="FX_ENEMY4_EXPLOSION"){
//			
//			if ( onTriggerEnterEx != null) {
//				 onTriggerEnterEx(col);
//			}
//		}
		
	}
}
