using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PoolObject))]
public class DHPoolGameObject : MonoBehaviour {
	
	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	protected PoolObject _poolObject;
	
	public GameObject ThisGameObject 
	{
        get { return _thisGameObject ; }
    }
	
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	
	public PoolObject ThisPoolObject
    {
        get { return _poolObject ; }
    }
	
	protected virtual void Awake() {
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_poolObject = GetComponent<PoolObject>() as PoolObject ;
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
	
	}
	
}
