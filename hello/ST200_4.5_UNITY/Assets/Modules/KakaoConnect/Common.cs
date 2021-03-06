using UnityEngine;
using System.Collections;

[System.Serializable]
public enum eKakaoActionType {
	None = -1,
	Initialize,
	Error,
	Login,
	Logout,
	Unregister,
	LocalUser,
	Friends,
	SendMessage,
	SendInviteMessage,
	PostStory,
	SendPaymentInfo,
	Max,
	LoadGameInfo,	//add
	LoadGameMe,	//add
	LoadGameFriends,	//add
	UseHeart,	//add
	UpdateResult,	//add
	DeleteMe,	//add
	UpdateMe,	//add
	LoadLeaderboard,	//add
	SendGameMessage,	//add
	LoadGameMessage,	//add
	AcceptMessage,	//add
	AcceptAllMessages,	//add
	MessageBlock,	//add
	SendGameInviteMessage,	//add
	SendLinkInviteMessage,	//add 20131119
	WorldRankingUpdateResult,
	WorldRankingData

}

//ST110k
public class Common {
	static public readonly string KAKAO_CLIENT_ID = "90928241260711424";
	static public readonly string KAKAO_CLIENT_SECRET = "qa1p/WZEpOjMFcfgxymren83mpwr+OXgOYrh05gk3emTOsn4sTIvV7T/O+BOUI5muV5Wb5fgl3Y46HkKxkoGOg==";
}

//Error json 정의
public struct sResponseError{
	private string _message;
	public string message{
		get{ return _message; }
		set{ _message = value; }
	}
	
	string _error;
	public string error{
		get{ return _error; }
		set{ _error = value; }
	}
	
	int _status;
	public int status{
		get{ return _status; }
		set{ _status = value; }
	}
}

