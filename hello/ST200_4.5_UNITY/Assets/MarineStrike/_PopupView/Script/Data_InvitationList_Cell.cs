using UnityEngine;
using System.Collections;

public class Data_InvitationList_Cell : MonoBehaviour {

	public string strUserInfo_UserId{ get; set; }

	public string strUserInfo_NickName{ get; set; }

	public string strUserInfo_ProfileImageUrl{ get; set; }

	public string strUserInfo_FriendNickname{ get; set; }

	public bool boolUserInfo_MessageBlocked{ get; set; }

	public bool boolUserInfo_SupportedDevice{ get; set; }

	public int intUserInfo_LastMessageSentAt{ get; set; }

	public bool boolUserInfo_MessageSent{ get; set; }

}
