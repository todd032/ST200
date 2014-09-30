using UnityEngine;
using System.Collections;

public class RankList_Btn_Up : MonoBehaviour {

	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_RankItemBtn_Up(RankPanelView.eRankType ePanelType_Input);
	protected Delegate_RankItemBtn_Up _delegate_RankItemBtn_Up ;
	public event Delegate_RankItemBtn_Up Event_Delegate_RankItemBtn_Up {
		add {
			_delegate_RankItemBtn_Up = null;
			if (_delegate_RankItemBtn_Up == null){
				_delegate_RankItemBtn_Up += value;
			}
		}
		remove {
			_delegate_RankItemBtn_Up -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================

	private RankPanelView.eRankType ePanelType;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init(RankPanelView.eRankType ePanelType_Input){
		
		
		Init_01_Initialize_Variable(ePanelType_Input);
	}
	
	private void Init_01_Initialize_Variable(RankPanelView.eRankType ePanelType_Input){
		
		ePanelType = ePanelType_Input;
	}
	
	// ==================== 버튼 클릭 정의 - Start ====================
	public void OnClick_RankItemBtn_Up(){

//		Debug.Log("RankList_Btn_Up.OnClick_RankItemBtn_Down() Run!!!!! ");

		if (_delegate_RankItemBtn_Up != null){
			_delegate_RankItemBtn_Up(ePanelType);
		}
	}
	
	// ==================== 버튼 클릭 정의 - End ====================
}
