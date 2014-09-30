using UnityEngine;
using System.Collections;


[AddComponentMenu("NGUI/Tween/Tween Scale Tk2dSprite")]
public class TweenTk2dSpriteScale : UITweener
{
	public tk2dSprite m_Sprite;
	public Vector3 from = Vector3.one;
	public Vector3 to = Vector3.one;
	public bool updateTable = false;
	
	Transform mTrans;
	UITable mTable;
	
	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }
	
	public Vector3 value { get { return m_Sprite.scale; } set { m_Sprite.scale = value; } }
	
	[System.Obsolete("Use 'value' instead")]
	public Vector3 scale { get { return this.value; } set { this.value = value; } }
	
	/// <summary>
	/// Tween the value.
	/// </summary>
	
	protected override void OnUpdate (float factor, bool isFinished)
	{
		value = from * (1f - factor) + to * factor;
		
		if (updateTable)
		{
			if (mTable == null)
			{
				mTable = NGUITools.FindInParents<UITable>(gameObject);
				if (mTable == null) { updateTable = false; return; }
			}
			mTable.repositionNow = true;
		}
	}
	
	/// <summary>
	/// Start the tweening operation.
	/// </summary>
	
	static public TweenScale Begin (GameObject go, float duration, Vector3 scale)
	{
		TweenScale comp = UITweener.Begin<TweenScale>(go, duration);
		comp.from = comp.value;
		comp.to = scale;
		
		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}
	
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value; }
	
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value; }
	
	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }
	
	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}