using UnityEngine;
using System.Collections;

public class DHCreatePoolManager : MonoBehaviour {
	
	//-- Fever Mode
	public GameObject feverTimeAlertObject ;
	public int feverTimeAlertObjectCreateNumber ;
	
	public GameObject feverBgStarEffectObject ;
	public int feverBgStarEffectObjectCreateNumber ;
	
	//-- Boss Enemy
	public GameObject bossWarningSpriteObject ;
	public int bossWarningSpriteObjectCreateNumber ;
	
	public GameObject[] bossEnemyObject ;
	public int bossEnemyObjectCreateNumber ;

	public GameObject[] bossEnemyBulletObjects;
	public int[] bossEnemyBulletObjectsNumber;

	public GameObject bossEnemyMissileBulletObject ;
	public int bossEnemyMissileBulletObjectCreateNumber ;
	
	public GameObject bossEnemyMineBulletObject ;
	public int bossEnemyMineBulletObjectCreateNumber ;

	public GameObject bossEnemyTridentBulletObject;
	public int bossEnemyTridentBulletObjectCreateNumber = 5;

	public GameObject bossEnemyThornBulletObject;
	public int bossEnemyThornBulletObjectCreateNumber = 10;

	public GameObject bossEnemyInkBulletObject;
	public int bossEnemyInkBulletObjectCreateNumber = 2;

	public GameObject[] bossEnemyLaserBulletObjects ;
	public int bossEnemyLaserBulletObjectsCreateNumber ;
	
	public GameObject[] bossEnemyEffectObject ;
	public int[] bossEnemyEffectObjectCreateNumbers ;
	//public int bossEnemyEffectObjectCreateNumber ;
	
	//-- Enemy
	public GameObject[] enemyEffectObject ;
	public int[] enemyEffectObjectCreateNumbers ;
	
	//-- Submarine Etc
	public GameObject[] submarineEtcEffectObject ;
	public int[] submarineEtcEffectObjectCreateNumbers ;
	
	
	//-- Subweapon Etc
	public GameObject[] subweaponEtcEffectObject ;
	public int[] subweaponEtcEffectObjectCreateNumbers ;
	
	
	//-- Drop Item
	public GameObject[] dropItemObject ;
	public int[] dropItemObjectCreateNumbers ;
	
	public GameObject[] dropItemGoldTypeObject ;
	public int[] dropItemGoldTypeObjectCreateNumbers ;
	
	
	//-- Etc Effect
	public GameObject allKillEffectGameObject ;
	public int allKillEffectGameObjectCreateNumber ;
	
	
	//-- Coin Magnet
	public GameObject[] CoinMagnetObject ;
	public int[] CoinMagnetObjectCreateNumbers ;
	
	//-- Item Use Effect
	public GameObject[] ItemUseEffectObjects ;
	public int ItemUseEffectObjectsCreateNumber ;


	//--MeteorWaningObject
	public GameObject meteorWaningObject ;
	public int meteorWaningObjectCreateNumber ;

	//--MeteorBulletObject
	public GameObject meteorBulletObject ;
	public int meteorBulletObjectCreateNumber ;
	
	void Awake() {
		
		//-- Fever Mode
		if(feverTimeAlertObject != null && feverTimeAlertObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(feverTimeAlertObject,feverTimeAlertObjectCreateNumber,true,feverTimeAlertObjectCreateNumber) ;
		}
		
		if(feverBgStarEffectObject != null && feverBgStarEffectObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(feverBgStarEffectObject,feverBgStarEffectObjectCreateNumber,true,feverBgStarEffectObjectCreateNumber) ;
		}
		
		
		//-- Boss Enemy
		if(bossWarningSpriteObject != null && bossWarningSpriteObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(bossWarningSpriteObject,bossWarningSpriteObjectCreateNumber) ;	
		}
		
		/*
		if(bossEnemyObject != null && bossEnemyObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(bossEnemyObject,bossEnemyObjectCreateNumber,true,bossEnemyObjectCreateNumber) ;
		}
		*/
		//if(bossEnemyObject.Length > 0 && bossEnemyObjectCreateNumber > 0) {
		//	for(int i = 0 ; i < bossEnemyObject.Length ; i++) {
		//		PoolManager.instance.CreatePrefabPool(bossEnemyObject[i], bossEnemyObjectCreateNumber,true,bossEnemyObjectCreateNumber) ;
		//	}
		//}

		for(int i = 0; i < bossEnemyBulletObjects.Length; i++)
		{
			PoolManager.instance.CreatePrefabPool(bossEnemyBulletObjects[i], bossEnemyBulletObjectsNumber[i]);
		}
		
		if(bossEnemyMissileBulletObject != null && bossEnemyMissileBulletObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(bossEnemyMissileBulletObject,bossEnemyMissileBulletObjectCreateNumber) ;
		}
		
		if(bossEnemyMineBulletObject != null && bossEnemyMineBulletObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(bossEnemyMineBulletObject,bossEnemyMineBulletObjectCreateNumber) ;
		}

		if(bossEnemyTridentBulletObject != null && bossEnemyTridentBulletObjectCreateNumber > 0)
		{
			PoolManager.instance.CreatePrefabPool(bossEnemyTridentBulletObject,bossEnemyTridentBulletObjectCreateNumber) ;
		}

		if(bossEnemyThornBulletObject != null && bossEnemyThornBulletObjectCreateNumber > 0)
		{
			PoolManager.instance.CreatePrefabPool(bossEnemyThornBulletObject,bossEnemyThornBulletObjectCreateNumber) ;
		}

		if(bossEnemyInkBulletObject != null && bossEnemyInkBulletObjectCreateNumber > 0)
		{
			PoolManager.instance.CreatePrefabPool(bossEnemyInkBulletObject, bossEnemyInkBulletObjectCreateNumber) ;
		}

		if(bossEnemyLaserBulletObjects.Length > 0 && bossEnemyLaserBulletObjectsCreateNumber > 0) {
			for(int i = 0 ; i < bossEnemyLaserBulletObjects.Length ; i++) {
				PoolManager.instance.CreatePrefabPool(bossEnemyLaserBulletObjects[i],bossEnemyLaserBulletObjectsCreateNumber) ;
			}
		}
		
		if(bossEnemyEffectObject.Length > 0 && bossEnemyEffectObjectCreateNumbers.Length > 0 && bossEnemyEffectObject.Length == bossEnemyEffectObjectCreateNumbers.Length) {
			for(int i = 0 ; i < bossEnemyEffectObject.Length ; i++) {
				if(bossEnemyEffectObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(bossEnemyEffectObject[i],bossEnemyEffectObjectCreateNumbers[i]) ;	
				}
			}
		}
		/*
		if(bossEnemyEffectObject.Length > 0 && bossEnemyEffectObjectCreateNumber > 0) {
			for(int i = 0 ; i < bossEnemyEffectObject.Length ; i++) {
				PoolManager.instance.CreatePrefabPool(bossEnemyEffectObject[i],bossEnemyEffectObjectCreateNumber) ;
			}
		}
		*/
		
		
		
		//-- Enemy
		/*
		if(enemyEffectObject.Length > 0 && enemyEffectObjectCreateNumber > 0) {
			for(int i = 0 ; i < enemyEffectObject.Length ; i++) {
				PoolManager.instance.CreatePrefabPool(enemyEffectObject[i],enemyEffectObjectCreateNumber) ;
			}
		}
		*/
		if(enemyEffectObject.Length > 0 && enemyEffectObjectCreateNumbers.Length > 0 && enemyEffectObject.Length == enemyEffectObjectCreateNumbers.Length) {
			for(int i = 0 ; i < enemyEffectObject.Length ; i++) {
				if(enemyEffectObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(enemyEffectObject[i],enemyEffectObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		
		//-- Submarine Etc
		if(submarineEtcEffectObject.Length > 0 && submarineEtcEffectObjectCreateNumbers.Length > 0 && submarineEtcEffectObject.Length == submarineEtcEffectObjectCreateNumbers.Length) {
			for(int i = 0 ; i < submarineEtcEffectObject.Length ; i++) {
				if(submarineEtcEffectObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(submarineEtcEffectObject[i],submarineEtcEffectObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		
		//-- Subweapon Etc
		if(subweaponEtcEffectObject.Length > 0 && subweaponEtcEffectObjectCreateNumbers.Length > 0 && subweaponEtcEffectObject.Length == subweaponEtcEffectObjectCreateNumbers.Length) {
			for(int i = 0 ; i < subweaponEtcEffectObject.Length ; i++) {
				if(subweaponEtcEffectObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(subweaponEtcEffectObject[i],subweaponEtcEffectObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		//-- Drop Item
		if(dropItemObject.Length > 0 && dropItemObjectCreateNumbers.Length > 0 && dropItemObject.Length == dropItemObjectCreateNumbers.Length) {
			for(int i = 0 ; i < dropItemObject.Length ; i++) {
				if(dropItemObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(dropItemObject[i],dropItemObjectCreateNumbers[i],true,dropItemObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		if(dropItemGoldTypeObject.Length > 0 && dropItemGoldTypeObjectCreateNumbers.Length > 0 && dropItemGoldTypeObject.Length == dropItemGoldTypeObjectCreateNumbers.Length) {
			for(int i = 0 ; i < dropItemGoldTypeObject.Length ; i++) {
				if(dropItemGoldTypeObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(dropItemGoldTypeObject[i],dropItemGoldTypeObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		//-- Etc Effect
		if(allKillEffectGameObject != null && allKillEffectGameObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(allKillEffectGameObject,allKillEffectGameObjectCreateNumber) ;
		}
		
		
		//-- Coin Magnet
		if(CoinMagnetObject.Length > 0 && CoinMagnetObjectCreateNumbers.Length > 0 && CoinMagnetObject.Length == CoinMagnetObjectCreateNumbers.Length) {
			for(int i = 0 ; i < CoinMagnetObject.Length ; i++) {
				if(CoinMagnetObjectCreateNumbers[i] > 0){
					PoolManager.instance.CreatePrefabPool(CoinMagnetObject[i],CoinMagnetObjectCreateNumbers[i]) ;	
				}
			}
		}
		
		//-- Item Use Effect
		if(ItemUseEffectObjects.Length > 0 && ItemUseEffectObjectsCreateNumber > 0) {
			for(int i = 0 ; i < ItemUseEffectObjects.Length ; i++) {
				PoolManager.instance.CreatePrefabPool(ItemUseEffectObjects[i],ItemUseEffectObjectsCreateNumber,true,ItemUseEffectObjectsCreateNumber) ;
			}
		}



		//--MeteorWaningObject
		if(meteorWaningObject != null && meteorWaningObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(meteorWaningObject, meteorWaningObjectCreateNumber) ;
		}

		//--MeteorBulletObject
		if(meteorBulletObject != null && meteorBulletObjectCreateNumber > 0) {
			PoolManager.instance.CreatePrefabPool(meteorBulletObject, meteorBulletObjectCreateNumber) ;
		}
		
	}
	
	void Start() {
		
	}
	
}
