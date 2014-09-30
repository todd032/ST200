using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageItemManager : MonoBehaviour {

	private static StageItemManager instance ;
	public static StageItemManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(StageItemManager)) as StageItemManager;
			}
			return instance;
		}
	}
	
	void OnDestroy()
	{
		instance = null;
	}

	public void TrySpawnItem(int _spawnitemindex, Vector3 _worldpos)
	{
		if(_spawnitemindex == 0)
		{
			return;
		}

		StageItemSpawnData spawndata = Managers.GameBalanceData.GetStageItemSpawnData(_spawnitemindex);

		int selectedindex = 0;

		float totalratio = 0f;
		for(int i = 0; i < spawndata.StageItemRatioList.Length; i++)
		{
			totalratio += spawndata.StageItemRatioList[i]; 
		}

		float randomvalue = Random.Range(0f, totalratio);
		float curatio = 0f;

		for(int i = 0; i < spawndata.StageItemRatioList.Length; i++)
		{
			curatio += spawndata.StageItemRatioList[i];
			if(curatio >= randomvalue)
			{
				selectedindex = spawndata.StageItemIndexList[i];
				break;
			}
		}

		if(selectedindex != 0)
		{
			SpawnStageItem(Managers.GameBalanceData.GetStageItemData(selectedindex), _worldpos);
		}
	}

	public List<StageItem> m_StageItemObjectList = new List<StageItem>();	
	protected List<StageItem> m_StageItem_Unused = new List<StageItem>();

	public StageItem SpawnStageItem(StageItemData _data, Vector3 _worldpos)
	{
		StageItem stageitem = GetStageItem(_data);
		stageitem.gameObject.SetActive(true);
		stageitem.SetPosition(_worldpos);
		return stageitem;
	}

	public void ReturnStageItem(StageItem _data)
	{
		_data.gameObject.SetActive(false);
		m_StageItem_Unused.Add(_data);
	}

	protected StageItem GetStageItem(StageItemData _stageitemdata)
	{
		StageItem selectedstageitem = null;
		for(int i = 0; i < m_StageItem_Unused.Count; i++)
		{
			StageItem curstageitem = m_StageItem_Unused[i];
			if((int)curstageitem.m_ItemImageType == _stageitemdata.ImageIndex)
			{
				selectedstageitem = curstageitem;
				m_StageItem_Unused.Remove(curstageitem);
				break;
			}
		}

		//Debug.Log("INDEX: " + _stageitemdata.Index + " IMAGE TYPE: " + _stageitemdata.ImageIndex + " EFFECT: " + _stageitemdata.EffectType);

		if(selectedstageitem == null)
		{
			for(int i = 0; i < m_StageItemObjectList.Count; i++)
			{
				StageItem curstageitem = m_StageItemObjectList[i];
				if((int)curstageitem.m_ItemImageType == _stageitemdata.ImageIndex)
				{
					GameObject go = Instantiate(curstageitem.gameObject) as GameObject;
					selectedstageitem = go.GetComponent<StageItem>();
					selectedstageitem.Init(_stageitemdata);
					break;
				}
			}
		}

		return selectedstageitem;
	}

}
