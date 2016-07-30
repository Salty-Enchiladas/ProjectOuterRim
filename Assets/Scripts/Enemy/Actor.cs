using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float speed;
    public float recalcDelay;
    public float enemyZClamp;
    public float enemyXPos;
    public float centerX;
    public float centerY;
    public float centerZ;
    public float maneuverRadius;

    public GameObject player;

    public bool DebugMode;

    private enum State
    {
        IDLE,
        MOVING,
        ATTACK,
        MANEUVER,
    }

    private State state = State.IDLE;

    private float m_speed_multi = 40;
    private float OldTime = 0;
    private float checkTime = 0;
    private float elapsedTime = 0;
    private float lerpSpeed;
    private float maneuverTimer;
    private float maneuverAngle;

    private bool onNode = true;
    private bool recalculating;
    private bool startManeuver;
    private bool hasChosenAction;

    private Vector3 m_target = new Vector3(0, 0, 0);
    private Vector3 currNode;

    private int nodeIndex;
    private int randomInt;

    private List<Vector3> path = new List<Vector3>();

    private NodeControl control;
    private WaveHandler _waveHandler;

    private void Awake()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        control = (NodeControl)gameManager.GetComponent(typeof(NodeControl));
        _waveHandler = gameManager.GetComponent<WaveHandler>();
        player = GameObject.Find("Player");
        //speed *= Time.deltaTime;
    }

    private void Start()
    {
        enemyZClamp = Random.Range(2f, 5f);
        enemyXPos = Random.Range(-0.5f, 0.5f);
        lerpSpeed = Random.Range(0.5f, 2.5f);

        _waveHandler.enemyCount++;
        player = GameObject.Find("Player");
        MoveOrder(player.transform.position);
    }

    private void OnDisable()
    {
        ChangeState(State.IDLE);
        startManeuver = true;
    }

    private void Update()
    {
        speed = Time.deltaTime * m_speed_multi;
        elapsedTime += Time.deltaTime;

        if (player.transform.position.z + enemyZClamp >= transform.position.z)      //if enemy is near player
        {
            if (!hasChosenAction)
            {
                hasChosenAction = true;
                randomInt = Random.Range(0, 2);
                
                if (randomInt == 0)
                {
                    ChangeState(State.ATTACK);
                }
                else
                {
                    ChangeState(State.MANEUVER);
                }
            }
        }

        if (state == State.MANEUVER)
        {
            if (startManeuver)
            {
                startManeuver = false;
                centerX += transform.position.x;
                centerY = transform.position.y;
                centerZ += transform.position.z;
            }
        }
    }

    private void FixedUpdate()
    {
        
        //if (state != State.ATTACK && state != State.MANEUVER)
        //{
        //    StartCoroutine(RecalculateMove());
        //}

        if(maneuverTimer >= (Mathf.PI * 2) - 0.2f)
        {
            hasChosenAction = false;
            maneuverTimer = 0;
        }

        if (elapsedTime > OldTime)
        {
            switch (state)
            {
                case State.IDLE:
                    break;

                case State.MOVING:
                    OldTime = elapsedTime + 0.01f;

                    transform.LookAt(player.transform);

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
                        }
                        else
                            MoveToward();
                    }
                    break;

                case State.ATTACK:
                    OldTime = elapsedTime + 0.01f;

                    transform.LookAt(player.transform);

                    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + enemyXPos, player.transform.position.y, player.transform.position.z + enemyZClamp), Time.deltaTime * lerpSpeed);
                    break;

                case State.MANEUVER:
                    OldTime = elapsedTime + 0.01f;

                    maneuverTimer += Time.deltaTime;
                    maneuverAngle = maneuverTimer;

                    if (transform.position.x > player.transform.position.x)
                    {
                        //Maneuver to the right of the player
                        this.transform.position = new Vector3(centerX + -(Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 2)));
                    }
                    else if (transform.position.x < player.transform.position.x)
                    {
                        //Maneuver to the left of the player
                        this.transform.position = new Vector3(-centerX + (Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 2)));
                    }
                    break;
            }
        }
    }    

    private void MoveToward()
    {
        if (DebugMode)
        {
            for (int i = 0; i < path.Count - 1; ++i)
            {
                Debug.DrawLine((Vector3)path[i], (Vector3)path[i + 1], Color.white, 0.01f);
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

    private IEnumerator RecalculateMove()
    {
        if (!recalculating)
        {
            recalculating = true;
            yield return new WaitForSeconds(recalcDelay);
            MoveOrder(player.transform.position);
            recalculating = false;
        }
    }

    private void CallRecalculateMove()
    {
        StartCoroutine(RecalculateMove());
    }
}