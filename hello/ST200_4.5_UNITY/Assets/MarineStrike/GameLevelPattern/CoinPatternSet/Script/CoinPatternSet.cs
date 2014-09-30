using UnityEngine;
using System.Collections;

public class CoinPatternSet : PatternObjectSet {
	
	//-----
	protected override void Awake (){
		base.Awake ();
		SetPatternObjectList() ;
	}
	
	protected override void OnEnable (){
		base.OnEnable ();
	}
	
	//--
	protected override void Start ()
	{
		base.Start ();
		
		//SetPatternSetSize() ; // Once PatternSet Position & Size Setting.
		
	}
	
	public override void ResetPatternObjects(float gameSpeed, int gameLevel) {
		
		base.ResetPatternObjects(gameSpeed, gameLevel) ;
		
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			_po.SetActivePatternObject(true) ;
			_po.ResetPatternObject(gameLevel) ;
		}
		
		//SetRelocationPatternObjects(gameSpeed) ;
		SetPatternSetSize() ;
		
	}
	
	public override void ResetPatternObjects(float gameSpeed, int gameLevel, float weightLevel) {
		
		base.ResetPatternObjects(gameSpeed, gameLevel, weightLevel) ;
		
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			_po.SetActivePatternObject(true) ;
			_po.ResetPatternObject(gameLevel, weightLevel) ;
		}
		
		//SetRelocationPatternObjects(gameSpeed) ;
		SetPatternSetSize() ;
		
	}

}
