using UnityEngine;
using System.Collections;

public class Continue_PopupView : MonoBehaviour {

	public UILabel _crystalExpend;
	public UILabel m_GoldPossessLabel;
	public UILabel _crystalHave;
	public UILabel m_TitleLabel;
	public UILabel m_ReviveWordLabel1;
	public UILabel m_ReviveWordLabel2;
	public UILabel m_ReviveWordLabel3;
	public UILabel m_ReviveWordLabel4;
	public UILabel m_CloseLabel;
	public UILabel m_ContinueLabel;

	[HideInInspector]
	public delegate void Continue_PopupViewDelegate(Continue_PopupView continue_PopupView, int state);
	protected Continue_PopupViewDelegate _continue_PopupViewDelegate ;
	public event Continue_PopupViewDelegate Continue_PopupViewEvent{

		add{
			
			_continue_PopupViewDelegate = null ;
			
			if (_continue_PopupViewDelegate == null){

				_continue_PopupViewDelegate += value;
			}
		}
		
		remove{

			_continue_PopupViewDelegate -= value;
		}
	}

	private void Awake() {
		m_TitleLabel.text = Constant.COLOR_CONTINUE_TITLE + TextManager.Instance.GetString(136);
		m_ReviveWordLabel1.text = Constant.COLOR_CONTINUE_DESCRIPTION + TextManager.Instance.GetString(130);
		m_ReviveWordLabel2.text = Constant.COLOR_CONTINUE_DESCRIPTION + TextManager.Instance.GetString(131);
		m_ReviveWordLabel3.text = Constant.COLOR_CONTINUE_REVIVE + TextManager.Instance.GetString(132);
		m_ReviveWordLabel4.text = Constant.COLOR_CONTINUE_DESCRIPTION + TextManager.Instance.GetString(133);
		m_CloseLabel.text = Constant.COLOR_CONTINUE_BUTTON + TextManager.Instance.GetString(135);
		m_ContinueLabel.text = Constant.COLOR_CONTINUE_BUTTON + TextManager.Instance.GetString(136);
		m_ContinueLabel.text = Constant.COLOR_CONTINUE_BUTTON + TextManager.Instance.GetString(136);
		m_GoldPossessLabel.text = Constant.COLOR_CONTINUE_GOLD_LABEL + TextManager.Instance.GetString(137);
	}
	
	private void Start() {


	}
	
	private void Update() {
		
	}
	
	
	
	
	public void Init_Continue_PopupView(){

		// 이어하기 소모 크리스탈 표시.
		setCrystal_Expend();
		
		// 사용자 보유 크리스탈 표시.
		setCrystal_UserHave();

	}

	private void setCrystal_Expend(){
		
		int intExpendCrystal = 0;

		if (Managers.GameBalanceData != null){

			intExpendCrystal = Managers.GameBalanceData.CrystalExpendForContinue;
		}

		if(intExpendCrystal == 0) {
			
			_crystalExpend.text = intExpendCrystal.ToString();
			
		}else {
			
			_crystalExpend.text = intExpendCrystal.ToString("#,#");
		}

	}

	private void setCrystal_UserHave(){

		int intUserCrystal = 0;
		
		if(Managers.UserData != null){
			
			intUserCrystal = Managers.UserData.GetGameJewel();
		}

		if(intUserCrystal == 0) {
			
			_crystalHave.text = intUserCrystal.ToString();
			
		}else {
			
			_crystalHave.text = intUserCrystal.ToString("#,#");
		}

	}

	
	// '닫기'버튼 클릭.
	public void OnClickClose(){

		if(_continue_PopupViewDelegate != null) {

			_continue_PopupViewDelegate(this, 100) ;	
		}	

		NGUITools.SetActive(gameObject, false);

	}

	// '이어하기'버튼 클릭.
	public void OnClickContinue(){

		if(_continue_PopupViewDelegate != null) {
			
			_continue_PopupViewDelegate(this, 101) ;	
		}

		NGUITools.SetActive(gameObject, false);

	}
}
