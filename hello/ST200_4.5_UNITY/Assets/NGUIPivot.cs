using UnityEngine;
using System.Collections;

public class NGUIPivot : MonoBehaviour {

	public enum NGUIHORIZONTALPIVOT
	{
		LEFT,
		MID,
		RIGHT,
	}

	public enum NGUIVERTICALPIVOT
	{
		TOP,
		MID,
		BOT
	}

	public NGUIHORIZONTALPIVOT m_HorizontalPivot;
	public NGUIVERTICALPIVOT m_VerticalPivot;
	public Camera m_Camera;
	// Use this for initialization
	void Start () {
		Init ();
	}

	public void Init()
	{
		float screenwidth = 854f * m_Camera.aspect;
		float screenheight = 854f;//(float)Screen.height;

		Vector3 pivotpos = transform.localPosition;
		if(m_HorizontalPivot == NGUIHORIZONTALPIVOT.LEFT)
		{
			pivotpos.x = -screenwidth / 2f;
		}else if(m_HorizontalPivot == NGUIHORIZONTALPIVOT.MID)
		{
			pivotpos.x = 0f;
		}else if(m_HorizontalPivot == NGUIHORIZONTALPIVOT.RIGHT)
		{
			pivotpos.x = screenwidth / 2f;
		}

		if(m_VerticalPivot == NGUIVERTICALPIVOT.TOP)
		{
			pivotpos.y = screenheight / 2f;
		}else if(m_VerticalPivot == NGUIVERTICALPIVOT.MID)
		{
			pivotpos.y = 0f;
		}else if(m_VerticalPivot == NGUIVERTICALPIVOT.BOT)
		{
			pivotpos.y = -screenheight / 2f;
		}

		transform.localPosition = pivotpos;
	}
}
