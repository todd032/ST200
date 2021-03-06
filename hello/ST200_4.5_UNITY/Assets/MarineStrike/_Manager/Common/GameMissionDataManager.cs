using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class GameMissionDataManager : MonoBehaviour {

	public struct MissionInfoData {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionType ; // 11 : Distance(In Game) , 12 : Distance(Cumulative) , 21 : Gold(In Game) , 22 : Gold(Cumulative) ,  31 : Kill_Enemy(In Game) , 32 : Kill_Enemy(Cumulative) , 42 : Kill_Boss(Cumulative) , 51 : Use_Item , 62 : PlayGame(Cumulative)
		public int MissionType {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionType = encryptString ;
			}
			get {
				if(_missionType == null || _missionType.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_missionType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _gradeInfo ; // 1: Lowest ~ 6 : Most
		public int GradeInfo {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gradeInfo = encryptString ;
			}
			get {
				if(_gradeInfo == null || _gradeInfo.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_gradeInfo,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionCondition ;
		public int MissionCondition {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionCondition = encryptString ;
			}
			get {
				if(_missionCondition == null || _missionCondition.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_missionCondition,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _compensationType ; // 1 : Gold   2 : Cube
		public int CompensationType {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_compensationType = encryptString ;
			}
			get {
				if(_compensationType == null || _compensationType.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_compensationType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _compensationNumber ;
		public int CompensationNumber {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_compensationNumber = encryptString ;
			}
			get {
				if(_compensationNumber == null || _compensationNumber.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_compensationNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
	} ;
	
	
	private List<MissionInfoData> _missionInfoDataGrade1List ;
	private List<MissionInfoData> _missionInfoDataGrade2List ;
	private List<MissionInfoData> _missionInfoDataGrade3List ;
	
	
	
	public struct MissionMessageData {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionNameEn ;
		public string MissionNameEn {
			get { return _missionNameEn ; }
			set { _missionNameEn = value ; }
		}
		
		private string _missionMessageEn ;
		public string MissionMessageEn {
			get { return _missionMessageEn ; }
			set { _missionMessageEn = value ; }
		}
		
		private string _missionNameKo ;
		public string MissionNameKo {
			get { return _missionNameKo ; }
			set { _missionNameKo = value ; }
		}
		
		private string _missionMessageKo ;
		public string MissionMessageKo {
			get { return _missionMessageKo ; }
			set { _missionMessageKo = value ; }
		}
		
		private string _missionNameHant ;
		public string MissionNameHant {
			get { return _missionNameHant ; }
			set { _missionNameHant = value ; }
		}
		
		private string _missionMessageHant ;
		public string MissionMessageHant {
			get { return _missionMessageHant ; }
			set { _missionMessageHant = value ; }
		}
		
		private string _missionNameHans ;
		public string MissionNameHans {
			get { return _missionNameHans ; }
			set { _missionNameHans = value ; }
		}
		
		private string _missionMessageHans ;
		public string MissionMessageHans {
			get { return _missionMessageHans ; }
			set { _missionMessageHans = value ; }
		}
		
		private string _missionNameJa ;
		public string MissionNameJa {
			get { return _missionNameJa ; }
			set { _missionNameJa = value ; }
		}
		
		private string _missionMessageJa ;
		public string MissionMessageJa {
			get { return _missionMessageJa ; }
			set { _missionMessageJa = value ; }
		}
		
		private string _missionNameFr ;
		public string MissionNameFr {
			get { return _missionNameFr ; }
			set { _missionNameFr = value ; }
		}
		
		private string _missionMessageFr ;
		public string MissionMessageFr {
			get { return _missionMessageFr ; }
			set { _missionMessageFr = value ; }
		}
		
	};
	
	private List<MissionMessageData> _missionMessageDataList ;
	
	
	
	//-----------------------------------
	private void Awake(){
		
		_missionInfoDataGrade1List = new List<MissionInfoData>() ;
		_missionInfoDataGrade2List = new List<MissionInfoData>() ;
		_missionInfoDataGrade3List = new List<MissionInfoData>() ;
		
		_missionMessageDataList = new List<MissionMessageData>() ;
		
		Initialize() ;
		
	}
	
	private void Initialize() {
		
	}
	
	
	//--- MissionInfoData
	public void SetMissionInfoData(MissionInfoData mid){
		
		int searchIndex = -1 ;
		int parameterIndex = mid.IndexNumber ;
		int parameterGradeInfo = mid.GradeInfo ;
		
		List<MissionInfoData> selectMissionInfoDataList = null ;
		if(parameterGradeInfo == 1 || parameterGradeInfo == 2) {
			selectMissionInfoDataList = _missionInfoDataGrade1List ;
		}else if(parameterGradeInfo == 3 || parameterGradeInfo == 4) {
			selectMissionInfoDataList = _missionInfoDataGrade2List ;
		}else if(parameterGradeInfo == 5 || parameterGradeInfo == 6) {
			selectMissionInfoDataList = _missionInfoDataGrade3List ;
		}
		
		
		for(int i = 0 ; i < selectMissionInfoDataList.Count ; i++){
			MissionInfoData _selectMissionInfoData = selectMissionInfoDataList[i] ;
			if(_selectMissionInfoData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			selectMissionInfoDataList.Add(mid) ;
		}else{
			selectMissionInfoDataList[searchIndex] = mid ;
		}
		
		
	}
	
	public void SetMissionInfoData(int indexNumber, int missionType, int gradeInfo, int missionCondition, int compensationType, int compensationNumber){
		
		int searchIndex = -1 ;
		
		
		List<MissionInfoData> selectMissionInfoDataList = null ;
		if(gradeInfo == 1 || gradeInfo == 2) {
			selectMissionInfoDataList = _missionInfoDataGrade1List ;
		}else if(gradeInfo == 3 || gradeInfo == 4) {
			selectMissionInfoDataList = _missionInfoDataGrade2List ;
		}else if(gradeInfo == 5 || gradeInfo == 6) {
			selectMissionInfoDataList = _missionInfoDataGrade3List ;
		}
		
		
		for(int i = 0 ; i < selectMissionInfoDataList.Count ; i++){
			MissionInfoData _selectMissionInfoData = selectMissionInfoDataList[i] ;
			if(_selectMissionInfoData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		MissionInfoData _mid = new MissionInfoData() ;
		_mid.IndexNumber = indexNumber ;
		_mid.MissionType = missionType ;
		_mid.GradeInfo = gradeInfo ;
		_mid.MissionCondition = missionCondition ;
		_mid.CompensationType = compensationType ;
		_mid.CompensationNumber = compensationNumber ;
		
		
		if(searchIndex == -1){ //No Exist
			selectMissionInfoDataList.Add(_mid) ;
		}else{
			selectMissionInfoDataList[searchIndex] = _mid ;
		}
		
	}
	
	public MissionInfoData GetMissionInfoData(int indexNumber, int gradeInfo){
		
		MissionInfoData _selectMissionInfoData = new MissionInfoData();
		
		//Debug.Log("INT INDEX: " + indexNumber + " GRGADEINFO: " + gradeInfo);
		List<MissionInfoData> selectMissionInfoDataList = null ;
		if(gradeInfo == 1 || gradeInfo == 2) {
			selectMissionInfoDataList = _missionInfoDataGrade1List ;
		}else if(gradeInfo == 3 || gradeInfo == 4) {
			selectMissionInfoDataList = _missionInfoDataGrade2List ;
		}else if(gradeInfo == 5 || gradeInfo == 6) {
			selectMissionInfoDataList = _missionInfoDataGrade3List ;
		}
		
		
		foreach(MissionInfoData _mid in selectMissionInfoDataList) {
			if(_mid.IndexNumber == indexNumber){
				_selectMissionInfoData = _mid ;
				break ;
			}
		}
		
		return _selectMissionInfoData ;
		
	}
	
	
	//public MissionInfoData GetRandomMissionInfoData(int currentGradeInfo, int missionType){
	public MissionInfoData GetRandomMissionInfoData(int currentGradeInfo){
		
		MissionInfoData selectMissionInfoData = new MissionInfoData() ;
		
		List<MissionInfoData> selectMissionInfoDataList = null ;
		if(currentGradeInfo == 1 || currentGradeInfo == 2) {
			selectMissionInfoDataList = _missionInfoDataGrade1List ;
		}else if(currentGradeInfo == 3 || currentGradeInfo == 4) {
			selectMissionInfoDataList = _missionInfoDataGrade2List ;
		}else if(currentGradeInfo == 5 || currentGradeInfo == 6) {
			selectMissionInfoDataList = _missionInfoDataGrade3List ;
		}
		
		//Add
		int randomSelectMissionInfoDataIndex = Random.Range(0, selectMissionInfoDataList.Count) ;
		selectMissionInfoData = selectMissionInfoDataList[randomSelectMissionInfoDataIndex] ;
		
		
		/*
		bool isSelectDone = false ;
		
		while(!isSelectDone && (selectMissionInfoDataList.Count > 0)){
		
			int randomSelectMissionInfoDataIndex = Random.Range(0, selectMissionInfoDataList.Count) ;
			
			MissionInfoData randomSelectMissionInfoData = selectMissionInfoDataList[randomSelectMissionInfoDataIndex] ;
			
			if(randomSelectMissionInfoData.MissionType == missionType) {
				selectMissionInfoData = randomSelectMissionInfoData ;
				isSelectDone = true ;
				break ;
			}
			
		}
		*/
		return selectMissionInfoData ;
	}
	
	public MissionInfoData GetRandomMissionInfoData(int currentGradeInfo, int grade1MissionType, int grade2MissionType, int grade3MissionType){
		
		MissionInfoData selectMissionInfoData = new MissionInfoData() ;
		
		List<MissionInfoData> selectMissionInfoDataList = null ;
		if(currentGradeInfo == 1 || currentGradeInfo == 2) {
			selectMissionInfoDataList = _missionInfoDataGrade1List ;
		}else if(currentGradeInfo == 3 || currentGradeInfo == 4) {
			selectMissionInfoDataList = _missionInfoDataGrade2List ;
		}else if(currentGradeInfo == 5 || currentGradeInfo == 6) {
			selectMissionInfoDataList = _missionInfoDataGrade3List ;
		}
		
		bool isSelectDone = false ;
		
		while(!isSelectDone && (selectMissionInfoDataList.Count > 0)){
		
			int randomSelectMissionInfoDataIndex = Random.Range(0, selectMissionInfoDataList.Count) ;
			
			MissionInfoData randomSelectMissionInfoData = selectMissionInfoDataList[randomSelectMissionInfoDataIndex] ;
			
			if((randomSelectMissionInfoData.MissionType != grade1MissionType) && (randomSelectMissionInfoData.MissionType != grade2MissionType) && (randomSelectMissionInfoData.MissionType != grade3MissionType)
			   && randomSelectMissionInfoData.MissionType != 72 && randomSelectMissionInfoData.MissionType != 71) {
				selectMissionInfoData = randomSelectMissionInfoData ;
				isSelectDone = true ;
				break ;
			}
			
		}
		
		return selectMissionInfoData ;
	}
	
	public List<MissionInfoData> GetMissionInfoDataGrade1List() {
		return 	_missionInfoDataGrade1List ;
	}
	
	public List<MissionInfoData> GetMissionInfoDataGrade2List() {
		return 	_missionInfoDataGrade2List ;
	}
	
	public List<MissionInfoData> GetMissionInfoDataGrade3List() {
		return 	_missionInfoDataGrade3List ;
	}
	
	public void SetMissionInfoDataGrade1List(List<MissionInfoData> missionInfoDataGrade1List) {
		_missionInfoDataGrade1List = missionInfoDataGrade1List ;
	}
	
	public void SetMissionInfoDataGrade2List(List<MissionInfoData> missionInfoDataGrade2List) {
		_missionInfoDataGrade2List = missionInfoDataGrade2List ;
	}
	
	public void SetMissionInfoDataGrade3List(List<MissionInfoData> missionInfoDataGrade3List) {
		_missionInfoDataGrade3List = missionInfoDataGrade3List ;
	}
	
	
	
	//--- MissionMessageData
	public void SetMissionMessageData(MissionMessageData mmd){
		
		int searchIndex = -1 ;
		int parameterIndex = mmd.IndexNumber ;
		
		
		for(int i = 0 ; i < _missionMessageDataList.Count ; i++){
			MissionMessageData _selectMissionMessageData = _missionMessageDataList[i] ;
			if(_selectMissionMessageData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_missionMessageDataList.Add(mmd) ;
		}else{
			_missionMessageDataList[searchIndex] = mmd ;
		}
		
		
	}
		
	public void SetMissionMessageData(int indexNumber, 
														string missionNameEn, string missionMessageEn, 
														string missionNameKo, string missionMessageKo, 
														string missionNameHant, string missionMessageHant, 
														string missionNameHans, string missionMessageHans, 
														string missionNameJa, string missionMessageJa, 
														string missionNameFr, string missionMessageFr ){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _missionMessageDataList.Count ; i++){
			MissionMessageData _selectMissionMessageData = _missionMessageDataList[i] ;
			if(_selectMissionMessageData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		MissionMessageData _mmd = new MissionMessageData() ;
		_mmd.IndexNumber = indexNumber ;
		_mmd.MissionNameEn = missionNameEn ;
		_mmd.MissionMessageEn = missionMessageEn ;
		_mmd.MissionNameKo = missionNameKo ;
		_mmd.MissionMessageKo = missionMessageKo ;
		_mmd.MissionNameHant = missionNameHant ;
		_mmd.MissionMessageHant = missionMessageHant ;
		_mmd.MissionNameHans = missionNameHans ;
		_mmd.MissionMessageHans = missionMessageHans ;
		_mmd.MissionNameJa = missionNameJa ;
		_mmd.MissionMessageJa = missionMessageJa ;
		_mmd.MissionNameFr = missionNameFr ;
		_mmd.MissionMessageFr = missionMessageFr ;
		
		
		if(searchIndex == -1){ //No Exist
			_missionMessageDataList.Add(_mmd) ;
		}else{
			_missionMessageDataList[searchIndex] = _mmd ;
		}
		
	}
	
	public string GetMissionName(int indexNumber, string languageCode){
		
		string selectMissionName = null ;
		
		foreach(MissionMessageData _mmd in _missionMessageDataList) {
			if(_mmd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectMissionName = _mmd.MissionNameEn ;
				}else if(languageCode.Equals("Ko")){
					selectMissionName = _mmd.MissionNameKo ;
				}else if(languageCode.Equals("Hant")){
					selectMissionName = _mmd.MissionNameHant ;
				}else if(languageCode.Equals("Hans")){
					selectMissionName = _mmd.MissionNameHans ;
				}else if(languageCode.Equals("Ja")){
					selectMissionName = _mmd.MissionNameJa ;
				}else if(languageCode.Equals("Fr")){
					selectMissionName = _mmd.MissionNameFr ;
				}
				break ;
			}
		}
		
		return selectMissionName ;
	}
	
	public string GetMissionMessage(int indexNumber, string languageCode){
		
		string selectMissionMessage = null ;
		
		foreach(MissionMessageData _mmd in _missionMessageDataList) {
			if(_mmd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectMissionMessage = _mmd.MissionMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectMissionMessage = _mmd.MissionMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectMissionMessage = _mmd.MissionMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectMissionMessage = _mmd.MissionMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectMissionMessage = _mmd.MissionMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectMissionMessage = _mmd.MissionMessageFr ;
				}
				break ;
			}
		}
		
		return selectMissionMessage ;
	}
	
	
	public List<MissionMessageData> GetMissionMessageDataList(){
		return 	_missionMessageDataList ;
	}
	
	public void SetMissionMessageDataList(List<MissionMessageData> missionMessageDataList) {
		_missionMessageDataList = missionMessageDataList ;
	}
	
	
	
	public void MakeGameMissionData() {
		
		SetMissionInfoData(101, 11, 1, 500, 1, 100) ;
		SetMissionInfoData(102, 11, 1, 700, 1, 300) ;
		SetMissionInfoData(103, 11, 2, 1000, 1, 500) ;
		SetMissionInfoData(104, 11, 3, 1500, 1, 700) ;
		SetMissionInfoData(105, 11, 5, 2000, 1, 1000) ;
		SetMissionInfoData(106, 11, 5, 2500, 1, 2000) ;
		
		SetMissionInfoData(151, 12, 3, 10000, 1, 500) ;
		SetMissionInfoData(152, 12, 3, 15000, 1, 1000) ;
		SetMissionInfoData(153, 12, 5, 20000, 1, 2000) ;
		
		SetMissionInfoData(201, 21, 1, 500, 1, 100) ;
		SetMissionInfoData(202, 21, 2, 1000, 1, 300) ;
		SetMissionInfoData(203, 21, 3, 1500, 1, 500) ;
		SetMissionInfoData(204, 21, 4, 2000, 1, 700) ;
		SetMissionInfoData(205, 21, 5, 2500, 1, 1000) ;
		SetMissionInfoData(206, 21, 6, 3000, 1, 1500) ;
		
		SetMissionInfoData(251, 22, 4, 5000, 1, 500) ;
		SetMissionInfoData(252, 22, 5, 10000, 1, 1000) ;
		SetMissionInfoData(253, 22, 6, 20000, 1, 2000) ;
		
		SetMissionInfoData(301, 31, 1, 50, 1, 100) ;
		SetMissionInfoData(302, 31, 2, 100, 1, 300) ;
		SetMissionInfoData(303, 31, 3, 150, 1, 500) ;
		SetMissionInfoData(304, 31, 4, 200, 1, 700) ;
		SetMissionInfoData(305, 31, 5, 250, 1, 1000) ;
		SetMissionInfoData(306, 31, 6, 500, 1, 3000) ;
		
		SetMissionInfoData(351, 32, 4, 500, 1, 300) ;
		SetMissionInfoData(352, 32, 5, 1000, 1, 500) ;
		SetMissionInfoData(353, 32, 6, 2000, 1, 1000) ;
		
		SetMissionInfoData(401, 42, 1, 1, 1, 100) ;
		SetMissionInfoData(402, 42, 2, 2, 1, 300) ;
		SetMissionInfoData(403, 42, 3, 3, 1, 500) ;
		SetMissionInfoData(404, 42, 4, 5, 1, 700) ;
		SetMissionInfoData(405, 42, 5, 10, 1, 1000) ;
		SetMissionInfoData(406, 42, 6, 20, 1, 3000) ;
		
		SetMissionInfoData(501, 51, 1, 1, 1, 500) ;
		SetMissionInfoData(511, 51, 2, 1, 1, 500) ;
		SetMissionInfoData(521, 51, 2, 1, 1, 500) ;
		SetMissionInfoData(531, 51, 2, 1, 1, 500) ;
		SetMissionInfoData(541, 51, 2, 1, 1, 500) ;
		SetMissionInfoData(551, 51, 3, 1, 1, 500) ;
		
		SetMissionInfoData(601, 62, 1, 5, 1, 100) ;
		SetMissionInfoData(602, 62, 2, 10, 1, 300) ;
		SetMissionInfoData(603, 62, 3, 20, 1, 500) ;
		SetMissionInfoData(604, 62, 4, 30, 1, 700) ;
		SetMissionInfoData(605, 62, 5, 50, 1, 1000) ;
		SetMissionInfoData(606, 62, 6, 100, 1, 3000) ;
		
		
		SetMissionMessageData(101, "101", "101", "500m 를 넘어라!", "한 게임에 500m 이상 진행", "101", "101", "101", "101", "101", "101", "101", "101") ;
		SetMissionMessageData(102, "102", "102", "700m 를 넘어라!", "한 게임에 700m 이상 진행", "102", "102", "102", "102", "102", "102", "102", "102") ;
		SetMissionMessageData(103, "103", "103", "1,000m를 넘어라!", "한 게임에 1,000m 이상 진행", "103", "103", "103", "103", "103", "103", "103", "103") ;
		SetMissionMessageData(104, "104", "104", "1,500m 를 넘어라!", "한 게임에 1,500m 이상 진행", "104", "104", "104", "104", "104", "104", "104", "104") ;
		SetMissionMessageData(105, "105", "105", "2,000m 를 넘어라!", "한 게임에 2,000m 이상 진행", "105", "105", "105", "105", "105", "105", "105", "105") ;
		SetMissionMessageData(106, "106", "106", "3,000m 를 넘어라!", "한 게임에 3,000m 이상 진행", "106", "106", "106", "106", "106", "106", "106", "106") ;
		
		SetMissionMessageData(151, "151", "151", "10,000m 를 넘어라!", "누적 거리 10,000m 이상 진행", "151", "151", "151", "151", "151", "151", "151", "151") ;
		SetMissionMessageData(152, "152", "152", "15,000m 를 넘어라!", "누적 거리 15,000m 이상 진행", "152", "152", "152", "152", "152", "152", "152", "152") ;
		SetMissionMessageData(153, "153", "153",  "20,000m 를 넘어라!", "누적 거리 20,000m 이상 진행", "153", "153", "153", "153", "153", "153", "153", "153") ;
		
		SetMissionMessageData(201, "201", "201", "500 골드를 모아라!", "한 게임에 500골드 이상 획득", "201", "201", "201", "201", "201", "201", "201", "201") ;
		SetMissionMessageData(202, "202", "202", "1,000 골드를 모아라!", "한 게임에 1,000골드 이상 획득", "202", "202", "202", "202", "202", "202", "202", "202") ;
		SetMissionMessageData(203, "203", "203", "1,500 골드를 모아라!", "한 게임에 1,500골드 이상 획득", "203", "203", "203", "203", "203", "203", "203", "203") ;
		SetMissionMessageData(204, "204", "204", "2,000 골드를 모아라!", "한 게임에 2,000골드 이상 획득", "204", "204", "204", "204", "204", "204", "204", "204") ;
		SetMissionMessageData(205, "205", "205", "2,500 골드를 모아라!", "한 게임에 2,500골드 이상 획득", "205", "205", "205", "205", "205", "205", "205", "205") ;
		SetMissionMessageData(206, "206", "206", "3,000 골드를 모아라!", "한 게임에 3,000골드 이상 획득", "206", "206", "206 ","206", "206", "206", "206", "206") ;
		
		SetMissionMessageData(251, "251", "251", "5,000 골드를 모아라!", "누적 5,000골드 이상 획득", "251", "251", "251", "251", "251", "251", "251", "251") ;
		SetMissionMessageData(252, "252", "252", "10,000 골드를 모아라!", "누적 10,000골드 이상 획득", "252", "252", "252", "252", "252", "252", "252", "252") ;
		SetMissionMessageData(253, "253", "253", "20,000 골드를 모아라!", "누적 20,000골드 이상 획득", "253", "253", "253", "253", "253", "253", "253", "253") ;
	
		SetMissionMessageData(301, "301", "301", "50 마리를 사냥하라!", "한 게임에 50마리 이상 몬스터 사냥", "301", "301", "301", "301", "301", "301", "301", "301") ;
		SetMissionMessageData(302, "302", "302", "100 마리를 사냥하라!", "한 게임에 100마리 이상 몬스터 사냥", "302", "302", "302", "302", "302", "302", "302", "302") ;
		SetMissionMessageData(303, "303", "303", "150 마리를 사냥하라!", "한 게임에 150마리 이상 몬스터 사냥", "303", "303", "303", "303", "303", "303", "303", "303") ;
		SetMissionMessageData(304, "304", "304", "200 마리를 사냥하라!", "한 게임에 200마리 이상 몬스터 사냥", "304", "304", "304", "304", "304", "304", "304", "304") ;
		SetMissionMessageData(305, "305", "305", "250 마리를 사냥하라!", "한 게임에 250마리 이상 몬스터 사냥", "305", "305", "305", "305", "305", "305", "305", "305") ;
		SetMissionMessageData(306, "306", "306", "500 마리를 사냥하라!", "한 게임에 500마리 이상 몬스터 사냥", "306", "306", "306 ","306", "306", "306", "306", "306") ;
		
		SetMissionMessageData(351, "351", "351", "500 마리를 사냥하라!", "누적 500마리 이상 몬스터 사냥", "351", "351", "351", "351", "351", "351", "351", "351") ;
		SetMissionMessageData(352, "352", "352", "1,000 마리를 사냥하라!", "누적 1,000마리 이상 몬스터 사냥", "352", "352", "352", "352", "352", "352", "352", "352") ;
		SetMissionMessageData(353, "353", "353", "2,000 마리를 사냥하라!", "누적 2,000마리 이상 몬스터 사냥", "353", "353", "353", "353", "353", "353", "353", "353") ;
		
		SetMissionMessageData(401, "401", "401", "1회 이상 보스를 사냥하라!", "보스를 1회 이상 사냥 성공", "401", "401", "401", "401", "401", "401", "401", "401") ;
		SetMissionMessageData(402, "402", "402", "2회 이상 보스를 사냥하라!", "보스를 2회 이상 사냥 성공", "402", "402", "402", "402", "402", "402", "402", "402") ;
		SetMissionMessageData(403, "403", "403", "3회 이상 보스를 사냥하라!", "보스를 3회 이상 사냥 성공", "403", "403", "403", "403", "403", "403", "403", "403") ;
		SetMissionMessageData(404, "404", "404", "5회 이상 보스를 사냥하라!", "보스를 5회 이상 사냥 성공", "404", "404", "404", "404", "404", "404", "404", "404") ;
		SetMissionMessageData(405, "405", "405", "10회 이상 보스를 사냥하라!", "보스를 10회 이상 사냥 성공", "405", "405", "405", "405", "405", "405", "405", "405") ;
		SetMissionMessageData(406, "406", "406", "20회 이상 보스를 사냥하라!", "보스를 20회 이상 사냥 성공", "406", "406", "406 ","406", "406", "406", "406", "406") ;

		SetMissionMessageData(501, "501", "501", "라스트 어택을 사용하라!", "라스트 어택 아이템을 구매하여 1회 이상 사용", "501", "501", "501", "501", "501", "501", "501", "501") ;
		SetMissionMessageData(511, "511", "511", "EMP를 사용하라~", "EMP 아이템을 구매하여 1회 이상 사용", "511", "511", "511", "511", "511", "511", "511", "511") ;
		SetMissionMessageData(521, "521", "521", "스타트 부스터를 사용하라!", "스타트 부스터 아이템을 구매하여 1회 이상 사용", "521", "521", "521", "521", "521", "521", "521", "521") ;
		SetMissionMessageData(531, "531", "531", "보호막을 사용하라!", "보호막 아이템을 구매하여 1회 이상 사용", "531", "531", "531", "531", "531", "531", "531", "531") ;
		SetMissionMessageData(541, "541", "541", "브레이크를 사용하라!", "브레이크 아이템을 구매하여 1회 이상 사용", "541", "541", "541", "541", "541", "541", "541", "541") ;
		SetMissionMessageData(551, "551", "551", "긴급수리를 사용하라!", "긴급수리 아이템을 구매하여 1회 이상 사용", "551", "551", "551 ","551", "551", "551", "551", "551") ;
		
		
		SetMissionMessageData(601, "601", "601", "5회 이상 플레이하라!", "5회 이상 플레이", "601", "601", "601", "601", "601", "601", "601", "601") ;
		SetMissionMessageData(602, "602", "602", "10회 이상 플레이하라!", "10회 이상 플레이", "602", "602", "602", "602", "602", "602", "602", "602") ;
		SetMissionMessageData(603, "603", "603", "20회 이상 플레이하라!", "20회 이상 플레이", "603", "603", "603", "603", "603", "603", "603", "603") ;
		SetMissionMessageData(604, "604", "604", "30회 이상 플레이하라!", "30회 이상 플레이", "604", "604", "604", "604", "604", "604", "604", "604") ;
		SetMissionMessageData(605, "605", "605", "50회 이상 플레이하라!", "50회 이상 플레이", "605", "605", "605", "605", "605", "605", "605", "605") ;
		SetMissionMessageData(606, "606", "606", "100회 이상 플레이하라!", "100회 이상 플레이", "606", "606", "606 ","606", "606", "606", "606", "606") ;
		
	}
	
}


















































