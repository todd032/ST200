using UnityEngine;
using System.Collections;

public class PauseGameUIListBoxObject : MonoBehaviour {
	
	public UILabel _missionListBoxTitleLabelObject ;
	public UILabel _missionListBoxExplainLabelObject ;
	public UILabel _cumulativeLabelObject ;
	public UISprite _cumulativeLabelBackgroundSpriteObject ;
	
	private void Awake() {
		
		NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
		NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
		
	}
	
	private void Start() {
		
	}
	
	public void DisplayMissionListBox(int indexNumber, int missionType, int gradeInfo, int missionCondition, int cumulativeNumber, bool isAttain, string missionName, string missionExplain) {
	
		_missionListBoxTitleLabelObject.text = missionName ;
		_missionListBoxExplainLabelObject.text = missionExplain ;
		
		NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, true) ;
		NGUITools.SetActive(_cumulativeLabelObject.gameObject, true) ;
		
		if(isAttain) {
			_cumulativeLabelObject.text = "[ffffff]Complete" ;
		}else{
			
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
				NGUITools.SetActive(_cumulativeLabelBackgroundSpriteObject.gameObject, false) ;
				NGUITools.SetActive(_cumulativeLabelObject.gameObject, false) ;
			}
			
		}
		
	}

}
