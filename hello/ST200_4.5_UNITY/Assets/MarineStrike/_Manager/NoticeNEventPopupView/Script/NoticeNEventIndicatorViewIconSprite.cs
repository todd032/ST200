using UnityEngine;
using System.Collections;

public class NoticeNEventIndicatorViewIconSprite : MonoBehaviour {

	private Transform _thisTransform ;
	
	private bool _isPlaying ;
	
	private void Awake() {
		_thisTransform = transform ;
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	public void InitIndicator() {
		_isPlaying = false ;
	}
	
	public void StartIndicator(){
		StopCoroutine("Play") ;
		_isPlaying = true ;
		StartCoroutine("Play") ;
	}
	
	public void StopIndicator() {
		StopCoroutine("Play") ;
		_isPlaying = false ;
	}
	
	private IEnumerator Play() {
	
		yield return null ;
		
		while(_isPlaying){
			
			_thisTransform.Rotate(Vector3.forward * (-10f*Time.timeScale), Space.World);
			
			yield return null ;
		}
		
	}
	
}
