using UnityEngine;
using System.Collections;

public class ClanBattleRewardItemView : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattleRewardItemViewDelegate(ClanBattleRewardItemView clanBattleRewardItemView, int state);
	protected ClanBattleRewardItemViewDelegate _clanBattleRewardItemViewDelegate ;
	public event ClanBattleRewardItemViewDelegate ClanBattleRewardItemViewEvent {
		add{
			
			_clanBattleRewardItemViewDelegate = null ;
			
			if (_clanBattleRewardItemViewDelegate == null)
				_clanBattleRewardItemViewDelegate += value;
		}
		
		remove{
			_clanBattleRewardItemViewDelegate -= value;
		}
	}
	

	private Transform _thisTransform ;


	public UISprite _clanBattleRewardItemViewBgSprite ;
	public UILabel _clanBattleRewardItemViewItemCountLabel ;
	public UISprite _clanBattleRewardItemViewItemSprite ;


	private void Awake(){

		_thisTransform = transform ;

	}
	
	private void Start() {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
	
	
	public void InitLoadClanBattleRewardItemView(int indexNumber, ClanBattlePopupView.ClanBattleRewardItem clanBattleRewardItem,  float baseLinePositionX, float baseLineWidth, long distancePointBaseScore, long distancePointEndScore){
		
		//clanBattleRewardItem.RewardItemDistance = 1000000 ;

		float calculationClanBattleRewardItemDistance = Mathf.Floor((baseLineWidth * clanBattleRewardItem.RewardItemDistance) / distancePointEndScore) ;

		_thisTransform.localPosition = new Vector3(baseLinePositionX+calculationClanBattleRewardItemDistance,  -120f,  (-0.1f *(indexNumber+1))) ;


		/*
		//_thisTransform.localPosition = new Vector3(baseLinePositionX+calculationClanBattleRewardItemDistance,  -120f,  (-1f *(indexNumber+1))) ;

		_clanBattleRewardItemViewBgSprite.depth = 14101 + (indexNumber * 100) ;
		_clanBattleRewardItemViewItemSprite.depth = 14111 + (indexNumber * 100) ;
		_clanBattleRewardItemViewItemCountLabel.depth = 14121 + (indexNumber * 100) ;
		*/


		int  clanBattleRewardItemBgType = (indexNumber % 4) ;
		if(clanBattleRewardItemBgType == 0){
			_clanBattleRewardItemViewBgSprite.spriteName = "ClanBattle_Bg_Item1" ;
		}else if(clanBattleRewardItemBgType == 1){
			_clanBattleRewardItemViewBgSprite.spriteName = "ClanBattle_Bg_Item2" ;
		}else if(clanBattleRewardItemBgType == 2){
			_clanBattleRewardItemViewBgSprite.spriteName = "ClanBattle_Bg_Item3" ;
		}else if(clanBattleRewardItemBgType == 3){
			_clanBattleRewardItemViewBgSprite.spriteName = "ClanBattle_Bg_Item4" ;
		}



		string ItemCountUnit = "" ;

		if(clanBattleRewardItem.RewardItemType == 1){ // 1 : Torpedo

			//_clanBattleRewardItemViewItemSprite Nothing...

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 2){ // 2 : Gold

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_Gold" ;

		}else if(clanBattleRewardItem.RewardItemType == 3){ // 3 : Jewel

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_Crystal" ;

		}else if(clanBattleRewardItem.RewardItemType == 1001){ //1001 : StartBooster

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_StartBooster" ;

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 1002){ //1002 : Shield

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_Shield" ;

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 1003){ //1003 : LastBooster

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_LastBooster" ;

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 1004){ // 1004 : Revive

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_Revive" ;

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 1005){ // 1005 : Brake

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_Brake" ;

			ItemCountUnit = "개" ;

		}else if(clanBattleRewardItem.RewardItemType == 1006){ // 1006 : EMP

			_clanBattleRewardItemViewItemSprite.spriteName = "ClanBattle_Item_EMP" ;

			ItemCountUnit = "개" ;

		}


		_clanBattleRewardItemViewItemCountLabel.text = clanBattleRewardItem.RewardItemCount.ToString("#,#") + ItemCountUnit ;


	}

}
