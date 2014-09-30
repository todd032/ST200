using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Camera m_UICamera;
	public PlayerControllerType m_ControllerType;
	public PlayerShip m_PlayerShip;
	// Use this for initialization
	void Start () {

	}

	public virtual void Init(PlayerShip _playership)
	{
		m_PlayerShip = _playership;
	}

	// Update is called once per frame
	protected virtual void Update () {

	}
}

public enum PlayerControllerType
{
	TOUCH,
	PAD,
}