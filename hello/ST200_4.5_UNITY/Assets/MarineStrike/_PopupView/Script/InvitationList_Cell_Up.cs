using UnityEngine;
using System.Collections;

public class InvitationList_Cell_Up : MonoBehaviour {

	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_InvitationList_Cell_Up();
	protected Delegate_InvitationList_Cell_Up _delegate_InvitationList_Cell_Up ;
	public event Delegate_InvitationList_Cell_Up Event_Delegate_InvitationList_Cell_Up {
		add {
			_delegate_InvitationList_Cell_Up = null;
			if (_delegate_InvitationList_Cell_Up == null){
				_delegate_InvitationList_Cell_Up += value;
			}
		}
		remove {
			_delegate_InvitationList_Cell_Up -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnClick_Up(){

//		Debug.Log ("InvitationList_Cell_Up.OnClick_Up() Run!!!!!");

		if (_delegate_InvitationList_Cell_Up != null){
			_delegate_InvitationList_Cell_Up();
		}
	}

}
