using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FluidSimulation : MonoBehaviour {

	private static FluidSimulation instance;
	public static FluidSimulation Instance
	{
		get
		{
			if(instance == null)
			{
				instance = (FluidSimulation)FindObjectOfType(typeof(FluidSimulation));
			}
			return instance;
		}
	}

	public int MaxWidth = 2;
	public List<float> CurDense = new List<float>();
	public List<float> PrevDense = new List<float>();
	public List<float> XVel = new List<float>();
	public List<float> XVelPrev = new List<float>();
	public List<float> YVel = new List<float>();
	public List<float> YVelPrev = new List<float>();
	public List<float> XInput = new List<float>();
	public List<float> YInput = new List<float>();
	public float m_Diffuse = 0.1f;
	public float m_Visco = 0.1f;

	void Start()
	{
		Init();
	}

	float prevx;
	float prevy;
	void Update()
	{


		if(Input.GetMouseButton(0))
		{
			//CurDense[FluidFunctions.IX(MaxWidth/2, MaxWidth/2, MaxWidth)] = 1f;
			//PrevDense[FluidFunctions.IX(MaxWidth/2,MaxWidth/2, MaxWidth)] = 1f;
			//XVel[FluidFunctions.IX(MaxWidth/2,MaxWidth/2, MaxWidth)] += 1f;
			float x = Input.mousePosition.x/(float)Screen.width;
			float y = Input.mousePosition.y/(float)Screen.height;

			XInput[FluidFunctions.IX((int)(x * MaxWidth), (int)(y * MaxWidth), MaxWidth)] += (x - prevx) * 1000f;
			YInput[FluidFunctions.IX((int)(x * MaxWidth), (int)(y * MaxWidth), MaxWidth)] += (y - prevy) * 1000f;

			prevx = x;
			prevy = y;
			//XVelPrev[FluidFunctions.IX(MaxWidth/2,MaxWidth/2, MaxWidth)] = 1f;
		}else if(Input.GetMouseButton(1))
		{
			CurDense[FluidFunctions.IX(MaxWidth/2, MaxWidth/2, MaxWidth)] += 1f * Time.deltaTime;
		}
	}

	void FixedUpdate()
	{		
		XVelPrev = new List<float>(XInput);
		YVelPrev = new List<float>(YInput);

		vel_step(MaxWidth, ref XVel, ref YVel, ref XVelPrev, ref YVelPrev, m_Visco, 0.1f);
		//Dens_Step(MaxWidth, ref CurDense, ref PrevDense,ref XVel,ref YVel, m_Diffuse, Time.fixedDeltaTime);
		for(int i = 0; i < (MaxWidth + 2) * (MaxWidth + 2); i++)
		{
			XInput[i] = 0f;
			YInput[i] = 0f;
		}
		//PrevDense = new List<float>(CurDense);
		//XVelPrev = new List<float>(XVel);
		//YVelPrev = new List<float>(YVel);
	}

	void OnDrawGizmos()
	{
		if(Application.isPlaying)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(Vector3.zero, 1f);
			//Gizmos.DrawRay(Vector3.zero, Vector3.up);
			//Debug.Log("SHOW");
			for(int i = 1; i <= MaxWidth; i++)
			{
				for(int j = 1; j <= MaxWidth; j++)
				{
					Vector2 startpos = new Vector2(i,j);
					Vector2 velocity = new Vector2(XVel[FluidFunctions.IX(i,j,MaxWidth)],YVel[FluidFunctions.IX(i,j,MaxWidth)]);

					Gizmos.color = Color.red;
					Gizmos.DrawLine(startpos, startpos + velocity * 10f);
					
					//Gizmos.color = new Color(1f,1f,1f, CurDense[FluidFunctions.IX(i,j,MaxWidth)]);
					//Gizmos.DrawSphere(startpos, 0.5f);
				}
			}
		}
	}

	void Init()
	{
		for(int i = 0; i < (MaxWidth + 2) * (MaxWidth + 2); i++)
		{
			CurDense.Add(0.0f);
			XVel.Add(1f);
			YVel.Add(1f);
		}
		PrevDense = new List<float>(CurDense);
		XVelPrev = new List<float>(XVel);
		YVelPrev = new List<float>(YVel);
		XInput = new List<float>(XVel);
		YInput = new List<float>(XVel);
	}

	void Swap(ref List<float> _l1,ref List<float> _l2)
	{

		List<float> temp = _l1;
		_l1 = _l2;
		_l2 = temp;

		/*
		_l1 = new List<float>(_l2);
		*/
	}

	void Add_Source(int _N, ref List<float> _x, ref List<float> _x0, float _dt)
	{
		int size = (_N + 2) * (_N + 2);
		for(int i = 0 ; i < size; i++)
		{
			_x[i] += _x0[i] * _dt;
		}
	}

	void Diffuse(int _N, int _b, ref List<float> _x,ref List<float> _x0, float _diff, float _dt)
	{

		float a = _dt*_diff*(float)_N*(float)_N;
		for(int solver = 0; solver < 20; solver++)
		{
			for(int i = 1; i <= _N; i++)
			{
				for(int j  = 1; j <= _N; j++)
				{
					_x[FluidFunctions.IX(i,j,_N)] = (_x0[FluidFunctions.IX(i,j,_N)] + 
						a *(_x[FluidFunctions.IX(i - 1,j,_N)] +_x[FluidFunctions.IX(i+1,j,_N)] +
						    _x[FluidFunctions.IX(i,j-1,_N)] + _x[FluidFunctions.IX(i,j + 1,_N)]))/(1f+4f*a);
				}
			}
			
			set_bnd(_N,_b,ref _x);
		}
	}

	void AdVect(int _N, int _b,ref List<float> _d,ref List<float> _d0,ref List<float> _u,ref List<float> _v, float _dt)
	{
		int i,j,i0,j0,i1,j1;
		float x,y,s0,t0,s1,t1,dt0;
		dt0 = _dt * (float)_N;

		for(i = 1; i <= _N; i++)
		{
			for(j= 1; j<= _N; j++)
			{
				x = (float)i -dt0*_u[FluidFunctions.IX(i,j,_N)];
				y = (float)j - dt0*_v[FluidFunctions.IX(i,j,_N)];
				if(x < 0.5f) x=0.5f;
				if(x > _N + 0.5f) x = _N + 0.5f;
				i0 = (int)x;
				i1 = i0 + 1;

				if(y < 0.5f) y=0.5f;
				if(y > _N + 0.5f) y = _N + 0.5f;
				j0 = (int)y;
				j1 = j0 + 1;

				s1 = x - (float)i0;
				s0 = 1f - s1;
				t1 = y - (float)j0;
				t0 = 1f - t1;

				_d[FluidFunctions.IX(i,j,_N)] = s0*(t0*_d0[FluidFunctions.IX(i0,j0,_N)]+t1*_d0[FluidFunctions.IX(i0,j1,_N)])+
				                                s1*(t0*_d0[FluidFunctions.IX(i1,j0,_N)]+t1*_d0[FluidFunctions.IX(i1,j1,_N)]);
			}
		}
		set_bnd(_N,_b,ref _d);
	}

	void Dens_Step(int _N, ref List<float> _x, ref List<float> _x0,ref List<float> _u,ref List<float> _v, float _diff, float _dt)
	{
		Add_Source(_N, ref _x,ref _x0, _dt);
		Swap(ref _x0, ref _x);
		Diffuse(_N,0,ref _x,ref _x0,_diff,_dt);
		Swap(ref _x0, ref _x);
		AdVect(_N,0,ref _x,ref _x0,ref _u,ref _v,_dt);
	}

	void vel_step(int _N, ref List<float> _u, ref List<float> _v, ref List<float> _u0,ref List<float> _v0, float _visc, float _dt)
	{
		Add_Source(_N, ref _u, ref _u0, _dt);
		Add_Source(_N,ref _v,ref _v0,_dt);
		Swap(ref _u0, ref _u);
		Diffuse(_N,1,ref _u,ref _u0,_visc,_dt);
		Swap(ref _v0, ref _v);
		Diffuse(_N,2,ref _v,ref _v0,_visc,_dt);
		Project(_N,ref  _u,ref _v,ref _u0,ref _v0);
		Swap(ref _u0, ref _u);
		Swap(ref _v0, ref _v);
		AdVect(_N,1,ref _u,ref _u0,ref _u0,ref _v0,_dt); 
		AdVect(_N,2,ref _v,ref _v0,ref _u0,ref _v0,_dt);
		Project(_N, ref _u,ref _v,ref _u0,ref _v0);
	}

	void Project(int _N,ref List<float> _u,ref List<float> _v,ref List<float> _p,ref List<float> _div)
	{
		int i,j,k;

		float h = 1.0f/(float)_N;
		for( i = 1; i <= _N; i++)
		{
			for(j = 1; j <=_N; j++)
			{
				_div[FluidFunctions.IX(i,j,_N)] = -0.5f*h*(_u[FluidFunctions.IX(i+1,j,_N)]-_u[FluidFunctions.IX(i-1,j,_N)] +
				                                           _v[FluidFunctions.IX(i,j + 1,_N)]-_v[FluidFunctions.IX(i,j-1,_N)]);
				_p[FluidFunctions.IX(i,j,_N)] = 0;
			}
		}

		set_bnd(_N,0,ref _div);
		set_bnd(_N,0,ref _p);

		for(k = 0; k < 20; k++)
		{
			for(i = 1; i <= _N; i++)
			{
				for(j = 1; j <=_N; j++)
				{
					_p[FluidFunctions.IX(i,j,_N)] = (_div[FluidFunctions.IX(i,j,_N)] + _p[FluidFunctions.IX(i - 1,j,_N)] 
					                                 + _p[FluidFunctions.IX(i + 1,j,_N)] + _p[FluidFunctions.IX(i,j - 1,_N)]
					                                 + _p[FluidFunctions.IX(i,j + 1,_N)])/4f;
				}
			}
			set_bnd(_N,0,ref _p);
		}

		for( i = 1; i <= _N; i++)
		{
			for(j = 1; j <=_N; j++)
			{
				_u[FluidFunctions.IX(i,j,_N)] -= 0.5f*(_p[FluidFunctions.IX(i+1,j,_N)]-_p[FluidFunctions.IX(i-1,j,_N)])/h;
				_v[FluidFunctions.IX(i,j,_N)] -= 0.5f*(_p[FluidFunctions.IX(i,j + 1,_N)]-_p[FluidFunctions.IX(i,j - 1,_N)])/h;
			}
		}
		set_bnd(_N,1,ref _u);
		set_bnd(_N,2,ref _v);
	}

	void set_bnd(int _N, int _b, ref List<float> _x)
	{
		int i;

		for(i = 1; i <=_N; i++)
		{
			_x[FluidFunctions.IX(0,i,_N)] = _b == 1 ? -_x[FluidFunctions.IX(1,i,_N)] : _x[FluidFunctions.IX(1,i,_N)];
			_x[FluidFunctions.IX(_N+1,i,_N)] = _b == 1 ? -_x[FluidFunctions.IX(_N,i,_N)] : _x[FluidFunctions.IX(_N,i,_N)];
			_x[FluidFunctions.IX(i,0,_N)] = _b == 2 ? -_x[FluidFunctions.IX(i,1,_N)] : _x[FluidFunctions.IX(i,1,_N)];
			_x[FluidFunctions.IX(i,_N+1,_N)] = _b == 2 ? -_x[FluidFunctions.IX(i,_N,_N)] : _x[FluidFunctions.IX(i,_N,_N)];
		}

		_x[FluidFunctions.IX(0,0,_N)] = 0.5f*(_x[FluidFunctions.IX(1,0,_N)] + _x[FluidFunctions.IX(0,1,_N)]);
		_x[FluidFunctions.IX(0,_N+1,_N)] = 0.5f*(_x[FluidFunctions.IX(1,_N+1,_N)] + _x[FluidFunctions.IX(0,_N,_N)]);
		_x[FluidFunctions.IX(_N+1,0,_N)] = 0.5f*(_x[FluidFunctions.IX(_N,0,_N)] + _x[FluidFunctions.IX(_N+1,1,_N)]);
		_x[FluidFunctions.IX(_N+1,_N+1,_N)] = 0.5f*(_x[FluidFunctions.IX(_N,_N+1,_N)] + _x[FluidFunctions.IX(_N+1,_N,_N)]);
	}

	public Vector3 GetVelocityAtPosition(Vector3 _pos)
	{
		//assume one cell is width of 1f;
		Vector3 velocity = Vector3.zero;
		int xindex = (int)_pos.x;
		if(xindex > MaxWidth + 1 || xindex < 0)
		{
			velocity.x = 0;
		}

		int yindex = (int)_pos.y;
		if(yindex > MaxWidth + 1 || yindex < 0)
		{
			velocity.y = 0;
		}

		if(!(xindex > MaxWidth + 1 || xindex < 0) && !(yindex > MaxWidth + 1 || yindex < 0))
		{
			velocity.x = XVel[FluidFunctions.IX(xindex,yindex, MaxWidth)];
			velocity.y = YVel[FluidFunctions.IX(xindex,yindex, MaxWidth)];
		}
		return velocity * 100f;
	}

	public void AddInputVel(Vector3 _pos, Vector3 _force)
	{
		int xindex = (int)_pos.x;
		xindex = Mathf.Clamp(xindex,1,MaxWidth + 1);
		
		int yindex = (int)_pos.y;
		yindex = Mathf.Clamp(yindex,1,MaxWidth + 1);
		
		XInput[FluidFunctions.IX(xindex,yindex, MaxWidth)] += _force.x;
		YInput[FluidFunctions.IX(xindex,yindex, MaxWidth)] += _force.y;
	}
}

public class FluidCell
{
	public Vector2 position;
	public Vector2 velocity;
	public float density;
	public float density_prev;
}

public static class FluidFunctions
{
	public static int IX(int i, int j, int N){ return  ((i)+(N+2)*(j));}
}