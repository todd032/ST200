using UnityEngine;
using System.Collections;

public class MissionPopupViewListBoxObject : MonoBehaviour {

	[HideInInspector]
	public delegate void MissionPopupViewListBoxObjectDelegate(MissionPopupViewListBoxObject missionPopupViewListBoxObject, int missionGradeType);
	protected MissionPopupViewListBoxObjectDelegate _missionPopupViewListBoxObjectDelegate ;
	public event MissionPopupViewListBoxObjectDelegate MissionPopupViewListBoxObjectEvent {
		add{
			
			_missionPopupViewListBoxObjectDelegate = null ;
			
			if (_missionPopupViewListBoxObjectDelegate == null)
        		_missionPopupViewListBoxObjectDelegate += value;
        }
		
		remove{
            _missionPopupViewListBoxObjectDelegate -= value;
		}
	}
	
	
	
	public UILabel _missionListBoxTitleLabelObject ;
	public UILabel _missionListBoxExplainLabelObject ;
	public UILabel _cumulativeLabelObject ;
	public UISprite _cumulativeLabelBackgroundSpriteObject ;
	public UIButton _missionRewardButton ;
	public UISprite _missionListBoxNewSpriteObject ;
	public UISprite m_MissionRewardImage;
	public UISprite m_MissionRewardBackground;
	public UILabel m_MissionRewardLabel;
	
	private int _missionGradeType ;
	
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadMissionPopupViewListBoxObject(){
		
		NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
		NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
		NGUITools.SetActive(_missionRewardButton.gameObject, false) ;
		NGUITools.SetActive(_missionListBoxNewSpriteObject.gameObject, false) ;
		
	}
	
	public void LoadMissionPopupViewListBoxObject(int missionGradeType) {
		
		_missionGradeType = missionGradeType ;
		
		SetMissionPopupViewListBoxObject(missionGradeType) ;
		
	}
	
	private void SetMissionPopupViewListBoxObject(int missionGradeType){
		
		if(Managers.UserData != null && Managers.GameMissionData != null) {
		
			string languageCode = Managers.UserData.LanguageCode ;
			
			UserDataManager.GameMissionData gameMissionGradeData = Managers.UserData.GetGameMissionData(missionGradeType) ;
			string missionGradeName = Managers.GameMissionData.GetMissionName(gameMissionGradeData.IndexNumber, languageCode) ;
			string missionGradeExplain = Managers.GameMissionData.GetMissionMessage(gameMissionGradeData.IndexNumber, languageCode) ;
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(gameMissionGradeData.IndexNumber, gameMissionGradeData.GradeInfo) ;

			int missiontype = getMissionInfoData.CompensationType;
			int missionval = getMissionInfoData.CompensationNumber;
			DisplayMissionListBox(gameMissionGradeData.IndexNumber, gameMissionGradeData.MissionType, gameMissionGradeData.GradeInfo, gameMissionGradeData.MissionCondition, gameMissionGradeData.CumulativeNumber, gameMissionGradeData.IsAttain,missionGradeName,missionGradeExplain,
			                      missiontype, missionval) ;
			
		}
		
	}
	
	private void DisplayMissionListBox(int indexNumber, int missionType, int gradeInfo, int missionCondition, int cumulativeNumber, 
	                                   bool isAttain, string missionName, string missionExplain,
	                                   int _rewardType, int _rewardAmount) {
	
		NGUITools.SetActive(_missionListBoxNewSpriteObject.gameObject, false) ;
		
		
		_missionListBoxTitleLabelObject.text = missionName ;
		_missionListBoxExplainLabelObject.text = missionExplain ;
		
		if(isAttain) {
			NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
			NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
			NGUITools.SetActive(_missionRewardButton.gameObject, true) ;
		}else{
			
			NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, true) ;
			NGUITools.SetActive(_missionRewardButton.gameObject, false) ;
			
			if(missionType == 12 || missionType == 22 || missionType == 32 || missionType == 42 || missionType == 62){
				
				NGUITools.SetActive(_cumulativeLabelObject.gameObject, true) ;
				
				string cumulativeLabelString = "" ;
			
				if(cumulativeNumber == 0) {
					cumulativeLabelString += "[ffffff]"+cumulativeNumber.ToString() ;
				}else{
					cumulativeLabelString += "[ffffff]"+cumulativeNumber.ToString("#,#") ;
				}
			 
				if(missionCondition == 0) {
					cumulativeLabelString += "[ffffff]/[d3a8d3]"+missionCondition.ToString() ;
				}else{
					cumulativeLabelString += "[ffffff]/[d3a8d3]"+missionCondition.ToString("#,#") ;
				}
			
				_cumulativeLabelObject.text = cumulativeLabelString ;
				
			}else {
				//_cumulativeLabelObject.text = "[ffae00]Failure" ;
				NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, true) ;
				NGUITools.SetActive(_cumulativeLabelObject.gameObject, true) ;
				_cumulativeLabelObject.text = TextManager.Instance.GetString(173);
			}
			
		}

		if(_rewardType == 1)
		{
			//gold
			m_MissionRewardImage.spriteName = "pop_img_gold2";
			m_MissionRewardImage.MakePixelPerfect();
			m_MissionRewardImage.transform.localScale = m_MissionRewardImage.transform.localScale/2f;
			string amounttext = "0";
			if(_rewardAmount != 0)
			{
				amounttext = _rewardAmount.ToString("#,#");
			}
			m_MissionRewardLabel.text = TextManager.Instance.GetReplaceString(172, amounttext);
		}else if(_rewardType == 2)
		{
			//crystal
			m_MissionRewardImage.spriteName = "pop_img_crystal1";
			m_MissionRewardImage.MakePixelPerfect();
			m_MissionRewardImage.transform.localScale = m_MissionRewardImage.transform.localScale/2f;
			string amounttext = "0";
			if(_rewardAmount != 0)
			{
				amounttext = _rewardAmount.ToString("#,#");
			}
			m_MissionRewardLabel.text = TextManager.Instance.GetReplaceString(171, amounttext);
		}
	}
	
	public void DisplayNewMissionListBox(int indexNumber, int grade, string missionName, string missionExplain)
	{
		NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, true) ;
		NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
		NGUITools.SetActive(_missionListBoxNewSpriteObject.gameObject, true) ;
		NGUITools.SetActive(_missionRewardButton.gameObject, false) ;
		
		_missionListBoxTitleLabelObject.text = missionName ;
		_missionListBoxExplainLabelObject.text = missionExplain ;

		GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(indexNumber, grade) ;
		int _rewardType = getMissionInfoData.CompensationType;
		int _rewardAmount = getMissionInfoData.CompensationNumber;
		if(_rewardType == 1)
		{
			//gold
			m_MissionRewardImage.spriteName = "pop_img_gold2";
			m_MissionRewardImage.MakePixelPerfect();
			m_MissionRewardImage.transform.localScale = m_MissionRewardImage.transform.localScale/2f;
			string amounttext = "0";
			if(_rewardAmount != 0)
			{
				amounttext = _rewardAmount.ToString("#,#");
			}
			m_MissionRewardLabel.text = TextManager.Instance.GetReplaceString(172, amounttext);
		}else if(_rewardType == 2)
		{
			//crystal
			m_MissionRewardImage.spriteName = "pop_img_crystal1";
			m_MissionRewardImage.MakePixelPerfect();
			m_MissionRewardImage.transform.localScale = m_MissionRewardImage.transform.localScale/2f;
			string amounttext = "0";
			if(_rewardAmount != 0)
			{
				amounttext = _rewardAmount.ToString("#,#");
			}
			m_MissionRewardLabel.text = TextManager.Instance.GetReplaceString(171, amounttext);
		}
	}
	
	
	private void OnClickMissionRewardButton() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_missionPopupViewListBoxObjectDelegate != null){
			_missionPopupViewListBoxObjectDelegate(this,_missionGradeType) ;
		}
	}
	
	
	
}
