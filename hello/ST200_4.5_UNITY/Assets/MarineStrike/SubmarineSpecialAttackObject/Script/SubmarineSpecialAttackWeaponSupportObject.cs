using UnityEngine;
using System.Collections;

public class SubmarineSpecialAttackWeaponSupportObject : SubmarineSpecialAttackObject {
	
	public float _startposition = -2f;	
	protected float StartPosition {
		set { 
			//string encryptString = LoadingWindows.NextE (value.ToString (), Constant.DefalutAppName);
			//_startposition = encryptString;
			_startposition = value;
		}
		get {
			//if (_startposition == null || _startposition.Equals ("")) {
			//	return 0f;	
			//}
			//string decryptString = LoadingWindows.NextD (_startposition, Constant.DefalutAppName);
			//float decryptFloat = float.Parse (decryptString);
			//return decryptFloat;
			
			return _startposition;
		}
	}
	
	protected float _endposition = 1.8f;
	protected float EndPosition {
		set { 
			//string encryptString = LoadingWindows.NextE (value.ToString (), Constant.DefalutAppName);
			//_endposition = encryptString;
			_endposition = value;
		}
		get {
			//if (_endposition == null || _endposition.Equals ("")) {
			//	return 0f;	
			//}
			//string decryptString = LoadingWindows.NextD (_endposition, Constant.DefalutAppName);
			//float decryptFloat = float.Parse (decryptString);
			//return decryptFloat;
			return _endposition;
		}
	}
	
	public float[] _initmovespeed;
	public float[] _movespeed;	
	protected float[] MoveSpeed {
		set { 
			//string encryptString = LoadingWindows.NextE (value.ToString (), Constant.DefalutAppName);
			//_movespeed = encryptString;
			_movespeed = value;
		}
		get {
			//if (_movespeed == null || _movespeed.Equals ("")) {
			//	return 0f;	
			//}
			//string decryptString = LoadingWindows.NextD (_movespeed, Constant.DefalutAppName);
			//float decryptFloat = float.Parse (decryptString);
			//return decryptFloat;
			return _movespeed;
		}
	}
	public float[] accel;
	
	public tk2dSprite[] _sprites;
	public tk2dAnimatedSprite[] _bombanims;
	
	public GameObject _Collider;
	protected override void Awake()
	{
		base.Awake();

	}
	
	public override void Reset(Submarine _sub, float _damage)
	{
		_Submarine = _sub;
		for(int i = 0; i < _sprites.Length; i++)
		{
			_sprites[i].spriteId = _sprites[i].Collection.GetSpriteIdByName("Bullet_" + _sub.SubmarineNum + "_30");
		}
	}
	
	public override void PlaySpecialAttack(float delaytime)
	{
		StartCoroutine(ProcessSpecialAttack(delaytime));
	}
	
	protected override IEnumerator ProcessSpecialAttack(float delaytime)
	{
		yield return new WaitForSeconds(delaytime);
		for(int i = 0; i < _initmovespeed.Length; i++)
		{
			_movespeed[i] = _initmovespeed[i];
		}
		
		//init position
		for(int i = 0; i < _sprites.Length; i++)
		{
			_sprites[i].transform.position = new Vector3(StartPosition, _sprites[i].transform.position.y, -1f);
		}
		for(int i = 0; i < _bombanims.Length; i++)
		{
			_bombanims[i].transform.position = new Vector3(StartPosition, 0f,0f);
		}
		_Collider.transform.position = new Vector3(StartPosition, 0f,0f);
		
		SetActive(true);
		
		int bombshowindex = 0;
		while(true)
		{
			//move collider and sprites
			for(int i = 0; i < _sprites.Length; i++)
			{
				_sprites[i].transform.Translate(Vector3.right * MoveSpeed[i] * Time.deltaTime);
			}
			_Collider.transform.Translate(Vector3.right * MoveSpeed[0]* Time.deltaTime);
			if(_Collider.transform.position.x > EndPosition - 0.6f)
			{
				_Collider.transform.position = new Vector3(EndPosition - 0.6f,
				                                           0f,
				                                           0f);
			}
			//check all the position and if all sprites are bigger than endpos, the stop the process
			bool finished = true;
			bool bombfinished = true;
			for(int i = 0; i < _sprites.Length; i++)
			{
				if(_sprites[i].transform.transform.position.x < EndPosition)
				{
					finished = false;
					break;
				}
			}
			
			//check bomb finished
			if(finished)
			{
				for(int i = 0; i < _bombanims.Length; i++)
				{
					if(!_bombanims[i].IsPlaying(_bombanims[i].CurrentClip))
					{
						_bombanims[i].gameObject.SetActive(false);
					}else
					{
						bombfinished = false;
					}
				}
			}
			
			if(finished && bombfinished)
			{
				break;
			}
			
			if(!finished)
			{
				//randomly display bombs
				if(Random.Range(0,100) < 50)
				{
					if(!_bombanims[bombshowindex].gameObject.activeSelf)
					{
						_bombanims[bombshowindex].gameObject.SetActive(true);
						_bombanims[bombshowindex].transform.position = _sprites[Random.Range(0,_sprites.Length)].transform.position;
						_bombanims[bombshowindex].transform.position += new Vector3(Random.Range(-0.2f,0.2f),
						                                                            Random.Range(-0.2f,0.2f),
						                                                            0f);
						_bombanims[bombshowindex].Play();
						bombshowindex++;
						bombshowindex %= _bombanims.Length;
					}
				}
				
				//check the done anims to be disabled
				for(int i = 0; i < _bombanims.Length; i++)
				{
					if(!_bombanims[i].IsPlaying(_bombanims[i].CurrentClip))
					{
						_bombanims[i].gameObject.SetActive(false);
					}
				}
			}
			
			for(int i = 0; i < accel.Length; i++)
			{
				_movespeed[i] += accel[i] * Time.deltaTime;
			}
			
			yield return null;
		}
		
		SetActive(false);
		yield break;
	}
	
	public override void SetActive(bool b)
	{
		for(int i = 0; i < _sprites.Length; i++)
		{
			_sprites[i].gameObject.SetActive(b);
		}
		for(int i = 0; i < _bombanims.Length; i++)
		{
			_bombanims[i].gameObject.SetActive(b);
		}
		_Collider.gameObject.SetActive(b);
		
	}
}
