using UnityEngine;
using System.Collections;

public class MissionGameUIListBoxObject : MonoBehaviour {

	public UILabel _missionListBoxTitleLabelObject ;
	public UILabel _missionListBoxExplainLabelObject ;
	public UILabel _cumulativeLabelObject ;
	public UISprite _cumulativeLabelBackgroundSpriteObject ;
	public UIButton _missionRewardButton ;
	public UISprite _missionListBoxNewSpriteObject ;	
	public UISprite m_MissionRewardImage;
	public UISprite m_MissionRewardBackground;
	public UILabel m_MissionRewardLabel;

	private void Awake() {
		
		NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
		NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
		NGUITools.SetActive(_missionRewardButton.gameObject, false) ;
		NGUITools.SetActive(_missionListBoxNewSpriteObject.gameObject, false) ;
		
	}
	
	private void Start() {
		
	}
	
	public void DisplayMissionListBox(int indexNumber, int missionType, int gradeInfo,
	                                  int missionCondition, int cumulativeNumber, bool isAttain, string missionName, string missionExplain)
	{
	
		NGUITools.SetActive(_missionListBoxNewSpriteObject.gameObject, false) ;
		
		
		_missionListBoxTitleLabelObject.text = missionName ;
		_missionListBoxExplainLabelObject.text = missionExplain ;
		
		if(isAttain) {
			NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
			NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
			NGUITools.SetActive(_missionRewardButton.gameObject, true) ;
		}else{
			
			NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, true) ;
			NGUITools.SetActive(_cumulativeLabelObject.gameObject, true) ;
			NGUITools.SetActive(_missionRewardButton.gameObject, false) ;
			
			if(missionType == 12 || missionType == 22 || missionType == 32 || missionType == 42 || missionType == 62){
				
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

				if(Managers.UserData != null) {
					string languageCode = Managers.UserData.LanguageCode ;
					_cumulativeLabelObject.text = "[ffffff]" + Constant.MissionFailureTextLabelString(languageCode) ;
				}else{
					_cumulativeLabelObject.text = "[ffffff]Failure" ;
				}

			}
			
		}

		GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(indexNumber, gradeInfo) ;
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
	
	
	public void DisplayNewMissionListBox(int indexNumber,int grade, string missionName, string missionExplain) {
	
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
	
	public void MissionRewardButtonEnable(){
		if(_missionRewardButton.gameObject.activeSelf){
			_missionRewardButton.isEnabled = true ;
		}
	}
	
	public void MissionRewardButtonDisable(){
		if(_missionRewardButton.gameObject.activeSelf){
			_missionRewardButton.isEnabled = false ;
		}
	}
	
	
}
