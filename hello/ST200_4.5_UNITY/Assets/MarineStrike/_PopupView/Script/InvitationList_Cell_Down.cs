using UnityEngine;
using System.Collections;

public class InvitationList_Cell_Down : MonoBehaviour {

	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_InvitationList_Cell_Down();
	protected Delegate_InvitationList_Cell_Down _delegate_InvitationList_Cell_Down ;
	public event Delegate_InvitationList_Cell_Down Event_Delegate_InvitationList_Cell_Down {
		add {
			_delegate_InvitationList_Cell_Down = null;
			if (_delegate_InvitationList_Cell_Down == null){
				_delegate_InvitationList_Cell_Down += value;
			}
		}
		remove {
			_delegate_InvitationList_Cell_Down -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnClick_Down(){

//		Debug.Log ("InvitationList_Cell_Down.OnClick_Down() Run!!!!!");

		if (_delegate_InvitationList_Cell_Down != null){
			_delegate_InvitationList_Cell_Down();
		}
	}

}
