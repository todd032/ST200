using UnityEngine;
using System.Collections;

public class RankingSceneTutorialView : MonoBehaviour {

	[HideInInspector]
	public delegate void RankingSceneTutorialViewDelegate(RankingSceneTutorialView rankingSceneTutorialView, int state);
	protected RankingSceneTutorialViewDelegate _rankingSceneTutorialViewDelegate ;
	public event RankingSceneTutorialViewDelegate RankingSceneTutorialViewEvent {
		add{
			
			_rankingSceneTutorialViewDelegate = null ;
			
			if (_rankingSceneTutorialViewDelegate == null)
        		_rankingSceneTutorialViewDelegate += value;
        }
		
		remove{
            _rankingSceneTutorialViewDelegate -= value;
		}
	}
		
	
	private void Awake(){

		
	}
	
	private void Start() {
		
	}
			
}
