using UnityEngine;
using System.Collections;

public class StageItem : MonoBehaviour {

	/// <summary>
	/// to set prefab's type  don't manipulate
	/// </summary>
	public StageItemImageType m_ItemImageType;
	public StageItemType m_StageItemType;
	public StageItemData m_StageItemData;

	public void Init(StageItemData _itemdata)
	{
		m_StageItemData = _itemdata;
		m_StageItemType = (StageItemType)_itemdata.EffectType;
	}

	public virtual void SetPosition(Vector3 _worldpos)
	{
		Vector3 newpos = _worldpos;
		transform.position = newpos;
	}

	protected void OnTriggerStay2D(Collider2D _col)
	{
		//Debug.Log ("NALE>:" + _col.gameObject.name);
		if(_col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
		{
			Vector3 movedirection = (transform.position - _col.transform.position);
			movedirection.z = 0f;
			movedirection.Normalize();
			transform.position += movedirection * Time.deltaTime * 5f;
		}
	}
}

public enum StageItemType
{
	NONE 						= 0,
	HEAL 						= 1,
	ATTACK_POWER				= 2,
	ATTACK_RATE					= 100,
	INVINCIBLE					= 101,
	HEALTH_INCREASE				= 102,

	GOLD_BAR					= 4,
	COIN						= 3,
}

public enum StageItemImageType
{
	HEAL						= 1,
	ATTACK_POWER				= 2,
	ATTACK_RATE					= 9,

	GOLD_BAR					= 4,
	COIN						= 3,

	HEALTH_INCREASE				= 5,
}

public enum StageItemDurationType
{
	INSTANCE 					= 0,
	TIME						= 1,
	INFINITE					= 2,
}