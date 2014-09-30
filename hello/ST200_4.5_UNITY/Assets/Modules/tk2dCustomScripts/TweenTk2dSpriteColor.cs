using UnityEngine;
using System.Collections;

[AddComponentMenu("NGUI/Tween/Tween Tk2d Sprite Color")]
public class TweenTk2dSpriteColor : UITweener
{
	public Color from = Color.white;
	public Color to = Color.white;

	tk2dSprite m_Sprite;
	bool mCached = false;
	
	void Cache ()
	{
		mCached = true;
		m_Sprite = GetComponent<tk2dSprite>();
	}
	
	[System.Obsolete("Use 'value' instead")]
	public Color color { get { return this.value; } set { this.value = value; } }
	
	/// <summary>
	/// Tween's current value.
	/// </summary>
	
	public Color value
	{
		get
		{
			if (!mCached) Cache();
			if(m_Sprite != null) return m_Sprite.color;
			return Color.black;
		}
		set
		{
			if (!mCached) Cache();
			if(m_Sprite != null) m_Sprite.color = value;
		}
	}
	
	/// <summary>
	/// Tween the value.
	/// </summary>
	
	protected override void OnUpdate (float factor, bool isFinished) { value = Color.Lerp(from, to, factor); }
	
	/// <summary>
	/// Start the tweening operation.
	/// </summary>
	
	static public TweenColor Begin (GameObject go, float duration, Color color)
	{
		#if UNITY_EDITOR
		if (!Application.isPlaying) return null;
		#endif
		TweenColor comp = UITweener.Begin<TweenColor>(go, duration);
		comp.from = comp.value;
		comp.to = color;
		
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