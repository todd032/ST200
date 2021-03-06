using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Android GCM Plugin
/// </summary>
public class GCM {
	
	private const string CLASS_NAME = "com.kskkbys.unitygcmplugin.UnityGCMRegister";
	
	private static GameObject _receiver = null;
	
	/// <summary>
	/// Initialize this plugin (Create receiver game object)
	/// </summary>
	public static void Initialize () {
		if (Application.platform == RuntimePlatform.Android) {
			if (_receiver == null) {
				_receiver = new GameObject ("GCMReceiver");
				_receiver.AddComponent ("GCMReceiver");
			}
		}
	}
	
	public static void ShowToast (string message) {
		if (Application.platform == RuntimePlatform.Android) {
#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass ("com.kskkbys.unitygcmplugin.Util")) {;
				cls.CallStatic ("showToast", message);
			}
#endif
		}
	}
	
	/// <summary>
	/// Register the specified senderIds.
	/// </summary>
	/// <param name='senderIds'>
	/// Sender identifiers.
	/// </param>
	public static void Register (params string[] senderIds) {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				string senderIdsStr = string.Join (",", senderIds);
				cls.CallStatic ("register", senderIdsStr);
			}
			#endif
		}
	}
	
	/// <summary>
	/// Unregister Android GCM
	/// </summary>
	public static void Unregister () {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				cls.CallStatic ("unregister");
			}
			#endif
		}
	}
	
	/// <summary>
	/// Determines whether this instance is registered.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is registered; otherwise, <c>false</c>.
	/// </returns>
	public static bool IsRegistered () {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				return cls.CallStatic<bool> ("isRegistered");
			}
			#endif
			return false;
		} else {
			return false;
		}
	}
	
	/// <summary>
	/// Gets the registration identifier.
	/// </summary>
	/// <returns>
	/// The registration identifier.
	/// </returns>
	public static string GetRegistrationId () {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				return cls.CallStatic<string> ("getRegistrationId");
			}
			#endif
			return null;
		} else {
			return null;
		}
	}
	
	/// <summary>
	/// Sets the registered on server.
	/// </summary>
	/// <param name='isRegistered'>
	/// Is registered.
	/// </param>
	public static void SetRegisteredOnServer (bool isRegistered) {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				cls.CallStatic ("setRegisteredOnServer", isRegistered);
			}
			#endif
		}
	}
	
	/// <summary>
	/// Determines whether this instance is registered on server.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is registered on server; otherwise, <c>false</c>.
	/// </returns>
	public static bool IsRegisteredOnServer () {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				return cls.CallStatic<bool> ("isRegisteredOnServer");
			}
			#endif
			return false;
		} else {
			return false;
		}
	}
	
	/// <summary>
	/// Sets the register on server lifespan.
	/// </summary>
	/// <param name='lifespan'>
	/// Lifespan.
	/// </param>
	public static void SetRegisterOnServerLifespan (long lifespan) {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				cls.CallStatic ("setRegisterOnServerLifespan", lifespan);
			}
			#endif
		}
	}
	
	/// <summary>
	/// Gets the register on server lifespan.
	/// </summary>
	/// <returns>
	/// The register on server lifespan.
	/// </returns>
	public static long GetRegisterOnServerLifespan () {
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
				return cls.CallStatic<long> ("getRegisterOnServerLifespan");
			}
			#endif
			return 0L;
		} else {
			return 0L;
		}
	}
	
    /// <summary>
 	/// Clear all status bar notifications
	/// </summary>
 public static void ClearAllNotifications () {
     if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
         using (AndroidJavaClass cls = new AndroidJavaClass ("com.kskkbys.unitygcmplugin.UnityGCMNotificationManager")) {
             cls.CallStatic ("clearAllNotifications");
         }
			#endif
     }
 }
 
    /// <summary>
 	/// Toggle status bar notifications on or off
	/// </summary>
 public static void SetNotificationsEnabled (bool enabled) {
     if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
         using (AndroidJavaClass cls = new AndroidJavaClass (CLASS_NAME)) {
             cls.CallStatic ("setNotificationsEnabled", enabled);
         }
			#endif
     }
 }

	public static void SetAlarmNotificationMessage(int _requestid, string _title, string _content,string _ticker, double _delaymilli)
	{
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass ("com.kskkbys.unitygcmplugin.UnityGCMNotificationManager")) {
				cls.CallStatic ("SetNotificationAlarm", _requestid.ToString(), _title,  _content,_ticker, _delaymilli.ToString());
			}
			#endif
		}
	}

	public static void ClearAlarmNotification(int _requestid)
	{
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass ("com.kskkbys.unitygcmplugin.UnityGCMNotificationManager")) {
				cls.CallStatic ("ClearNotificationAlarm", _requestid.ToString());
			}
			#endif
		}
	}
 
	/// <summary>
	/// Sets the error callback.
	/// </summary>
	/// <param name='onError'>
	/// On error.
	/// </param>
	public static void SetErrorCallback (System.Action<string> onError) {
		GCMReceiver._onError = onError;
	}
	/// <summary>
	/// Sets the message callback.
	/// </summary>
	/// <param name='onMessage'>
	/// On message.
	/// </param>
	public static void SetMessageCallback (System.Action<Dictionary<string, object>> onMessage) {
		GCMReceiver._onMessage = onMessage;
	}
	/// <summary>
	/// Sets the registered callback.
	/// </summary>
	/// <param name='onRegistered'>
	/// On registered.
	/// </param>
	public static void SetRegisteredCallback (System.Action<string> onRegistered) {
		GCMReceiver._onRegistered = onRegistered;
	}
	/// <summary>
	/// Sets the unregistered callback.
	/// </summary>
	/// <param name='onUnregistered'>
	/// On unregistered.
	/// </param>
	public static void SetUnregisteredCallback (System.Action<string> onUnregistered) {
		GCMReceiver._onUnregistered = onUnregistered;
	}
	/// <summary>
	/// Sets the delete messages callback.
	/// </summary>
	/// <param name='onDeleteMessages'>
	/// On delete messages.
	/// </param>
	public static void SetDeleteMessagesCallback (System.Action<int> onDeleteMessages) {
		GCMReceiver._onDeleteMessages = onDeleteMessages;
	}
}
