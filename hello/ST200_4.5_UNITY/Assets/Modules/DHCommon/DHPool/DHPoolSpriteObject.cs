using UnityEngine;
using System.Collections;

public class DHPoolSpriteObject : DHPoolGameObject {
	
	[HideInInspector]
	public delegate void SpriteObjectDelegate(DHPoolSpriteObject poolSpriteObject, int state);
	protected SpriteObjectDelegate _spriteObjectStateDelegate ;
	public event SpriteObjectDelegate SpriteObjectStateDelegate {
		add{
			
			_spriteObjectStateDelegate = null ;
			
			if (_spriteObjectStateDelegate == null)
        		_spriteObjectStateDelegate += value;
        }
		
		remove{
            _spriteObjectStateDelegate -= value;
		}
	}
	
	
	protected float _screenSizeHeight ;
	protected float _screenSizeWidth ;
	
	protected tk2dSprite _thisSprite ; //Caching tk2dSprite.
	
	protected Vector2 _spriteSize ;
	protected Vector2 _spriteCenter ;
	
	protected Vector2 _spriteUntrimmedSize ;
	protected Vector2 _spriteUntrimmedCenter ;
	
	public tk2dSprite ThisSprite 
	{
		get { return _thisSprite ; }
	}
	
	public Vector2 SpriteSize 
	{
		get { return _spriteSize ; }
	}
	
	public Vector2 SpriteCenter 
	{
		get { return _spriteCenter ; }
	}
	
	public Vector2 SpriteUntrimmedSize 
	{
		get { return _spriteUntrimmedSize ; }
	}
	
	public Vector2 SpriteUntrimmedCenter 
	{
		get { return _spriteUntrimmedCenter ; }
	}
	
	
	protected override void Awake ()
	{
		base.Awake ();
		
		_screenSizeHeight = 2f * Camera.main.orthographicSize;
		_screenSizeWidth = _screenSizeHeight * Camera.main.aspect;
		
		_thisSprite = GetComponentInChildren<tk2dSprite>() as tk2dSprite ; //Caching tk2dSprite.
		
		_spriteSize = new Vector2(_thisSprite.GetBounds().extents.x, _thisSprite.GetBounds().extents.y) ;
		_spriteCenter = new Vector2(_thisSprite.GetBounds().center.x, _thisSprite.GetBounds().center.y) ;		
		_spriteUntrimmedSize = new Vector2(_thisSprite.GetUntrimmedBounds().extents.x, _thisSprite.GetUntrimmedBounds().extents.y) ;
		_spriteUntrimmedCenter = new Vector2(_thisSprite.GetUntrimmedBounds().center.x, _thisSprite.GetUntrimmedBounds().center.y) ;
		
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	public virtual void ResetSpriteObject(){
	}
	
	public virtual void ResetSpriteObject(float settingValue){
	}
	
	public virtual void ResetSpriteObject(float gameSpeed, float settingValue){	
	}
	
	public virtual void DestroySpriteObject(int destroyType) {
		if(destroyType == 0) {
			PoolManager.Despawn(_thisGameObject) ;
		}
	}
	
	// Use this for initialization
	protected override void Start () {
	
	}

}
