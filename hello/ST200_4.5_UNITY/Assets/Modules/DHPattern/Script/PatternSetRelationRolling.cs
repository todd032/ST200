using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class PatternSetRelationRolling : PatternSetRolling {

	
	//****************************
	//--- Event Process Part.
	protected override void PatternSetMoveScreenOut(PatternObjectSet _pos) {
		base.PatternSetMoveScreenOut(_pos) ;
		
		/*
		// To Do Here.
		_pos.MovePatternSet(false, 2) ; // State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
		//_pos.ReadyPatternSetPosition() ; //// Attach
		PoolManager.Despawn(_pos.ThisGameObject) ;
		*/
		
		PatternObjectSet _poDequeue = _patternObjectSetQueue.Dequeue() ;
		_poDequeue.MovePatternSet(false,2) ;
		PoolManager.Despawn(_poDequeue.ThisGameObject) ;
		
		
		if(_isPatternManagerActive) {
			
			if(_patternSetStop != null){
				_patternSetStop(100) ;	
			}
			
			//
			//_patternObjectSetQueue.Dequeue() ;
			
			/*
			PatternObjectSet _poDequeue = _patternObjectSetQueue.Dequeue() ;
			_poDequeue.MovePatternSet(false,2) ;
			PoolManager.Despawn(_poDequeue.ThisGameObject) ;
			*/
			
			
			PatternObjectSet _po = CreatePatternSet() ;
			//_po.ResetPatternObjects(_patternObjectSetMoveSpeed, _patternLevel) ; //
			_po.ResetPatternObjects(_patternObjectSetMoveSpeed, _patternLevel, _weightLevel) ;
			_patternObjectSetQueue.Enqueue(_po) ;
		
			_currentPatternObjectSet = _patternObjectSetQueue.Peek() as PatternObjectSet ;
			
			
			_currentPatternObjectSet.PatternSetMoveSpeed = _patternObjectSetMoveSpeed ;
			//
			
			
			//Debug.Log("selectPatternLevel  : " +  selectPatternLevel + "      selectPatternName    " + selectPatternName) ;
//			Debug.Log("create  : " +  _po.ThisPoolObject.PrefabName + "  current   : "+  _currentPatternObjectSet.ThisPoolObject.PrefabName + "   speed    " + _patternObjectSetMoveSpeed) ;
			
			
			StartPatternObjectSet() ;
			
		}else{
			
			ClearPatternObejctSet() ;
			
			if(_patternSetStop != null){
				_patternSetStop(0) ;	
			}
			
		}
		
	}
	
	protected override void PatternSetMoveScreenEnd(PatternObjectSet _pos) {
		base.PatternSetMoveScreenEnd(_pos) ;
		
		// To Do Here.
		
	}
	
	protected override void PatternSetMoveScreenStart(PatternObjectSet _pos) {
		base.PatternSetMoveScreenStart(_pos) ;
		
		// To Do Here.
		
	}
	
	protected override void PatternSetMoveScreenDestination(PatternObjectSet _pos) {
		base.PatternSetMoveScreenDestination(_pos) ;
		
		// To Do Here.
		
	}
	
	protected override void PatternObjectSetStateDelegate(PatternObjectSet _pos, PatternObject _po, int state) {
		base.PatternObjectSetStateDelegate(_pos, _po, state) ;
		
		// To Do Here.
		
	}
	
	//--- Event Process Part End.
	//****************************
	
}
