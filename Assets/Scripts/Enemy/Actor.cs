using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour 
{
    public bool DebugMode;
    public float speed;
    public GameObject player;

	enum State
	{
		IDLE,
		MOVING,
	}

    State state = State.IDLE;
	
	float m_speed_multi = 50;
    float OldTime = 0;
    float checkTime = 0;
    float elapsedTime = 0;
	
	bool onNode = true;
    bool recalculating;

	Vector3 m_target = new Vector3(0, 0, 0);
	Vector3 currNode;

	int nodeIndex;

	List<Vector3> path = new List<Vector3>();

	NodeControl control;
    WaveHandler _waveHandler;	
	
	void Awake()
	{
		GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        control = (NodeControl)gameManager.GetComponent(typeof(NodeControl));
        _waveHandler = gameManager.GetComponent<WaveHandler>();
        player = GameObject.Find("Player");
        //speed *= Time.deltaTime;
	}

    void Start()
    {
        _waveHandler.enemyCount++;
        player = GameObject.Find("Player");
        MoveOrder(player.transform.position);
    }

    void OnDisable()
    {
        ChangeState(State.IDLE);
    }

    void FixedUpdate()
    {
        StartCoroutine(RecalculateMove());
    }
	
	void Update () 
	{
		speed = Time.deltaTime * m_speed_multi;
		elapsedTime += Time.deltaTime;
		
		if (elapsedTime > OldTime)
		{
			switch (state)
			{
			    case State.IDLE:
				    break;
				
			    case State.MOVING:
				    OldTime = elapsedTime + 0.01f;

				    if (elapsedTime > checkTime)
				    {
					    checkTime = elapsedTime + 1;
					    SetTarget();
				    }
				
				    if (path != null)
				    {
					    if (onNode)
					    {
						    onNode = false;
						    if (nodeIndex < path.Count)
							    currNode = path[nodeIndex];
					    } else
						    MoveToward();
				    }
				    break;
			}
		}
	}
	
	void MoveToward()
	{
		if (DebugMode)
		{
			for (int i=0; i<path.Count-1; ++i)
			{
				Debug.DrawLine((Vector3)path[i], (Vector3)path[i+1], Color.white, 0.01f);
			}
		}
		
		Vector3 newPos = transform.position;

		float Xdistance = newPos.x - currNode.x;

        if (Xdistance < 0)
        {
            Xdistance -= Xdistance * 2;
        }

		float Ydistance = newPos.z - currNode.z;

        if (Ydistance < 0)
        {
            Ydistance -= Ydistance * 2;
        }
	
		if ((Xdistance < 0.1 && Ydistance < 0.1) && m_target == currNode) //Reached target
		{
			ChangeState(State.IDLE);
		}
		else if (Xdistance < 0.1 && Ydistance < 0.1)
		{
			nodeIndex++;
			onNode = true;
		}
		
		/***Move toward waypoint***/
		Vector3 motion = currNode - newPos;
		motion.Normalize();
		newPos += motion * speed;
		
		transform.position = Vector3.Lerp(transform.position, newPos, speed);
	}
	
	private void SetTarget()
	{
		path = control.Path(transform.position, m_target);
		nodeIndex = 0;
		onNode = true;
	}
	
	public void MoveOrder(Vector3 pos)
	{
		m_target = pos;
		SetTarget();
		ChangeState(State.MOVING);
	}
	
	private void ChangeState(State newState)
	{
		state = newState;
	}

    IEnumerator RecalculateMove()
    {
        if (!recalculating)
        {
            recalculating = true;
            yield return new WaitForSeconds(0.25f);
            MoveOrder(player.transform.position);
            recalculating = false;
        }
    }

    void CallRecalculateMove()
    {
        StartCoroutine(RecalculateMove());
    }
}
