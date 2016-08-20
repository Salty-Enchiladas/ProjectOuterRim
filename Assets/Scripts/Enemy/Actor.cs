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
    public float maneuverRadiusMin;
    public float maneuverRadiusMax;

    public GameObject player;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    public bool DebugMode;

    private enum State
    {
        IDLE,
        MOVING,
        MANEUVER,
        STRAFE,
    }

    private State state = State.MOVING;

    GameObject playerTarget;

    private float OldTime = 0;
    private float checkTime = 0;
    private float elapsedTime = 0;
    private float lerpSpeed;
    private float maneuverTimer;
    private float maneuverAngle;
    private float _centerX;
    private float _centerY;
    private float _centerZ;
    private float m_speed_multi = 40;

    private bool onNode = true;
    private bool recalculating;
    private bool startManeuver;
    private bool hasChosenAction;
    private bool ceasedFire = true;
    private bool maneuverLeft;
    private bool hasChosenDirection;

    private Vector3 m_target = new Vector3(0, 0, 0);
    private Vector3 currNode;

    private int nodeIndex;
    private int randomInt;

    private List<Vector3> path = new List<Vector3>();

    private NodeControl control;
    private WaveHandler _waveHandler;

    private Transform lookAtPoint;      //The point that the ship looks at during the maneuver state

    private void Awake()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        control = (NodeControl)gameManager.GetComponent(typeof(NodeControl));
        _waveHandler = gameManager.GetComponent<WaveHandler>();

        _centerX = centerX + Random.Range(-500, 500);
        _centerY = centerY + Random.Range(-500, 500);
        _centerZ = centerZ + Random.Range(-500, 500);

        gun1 = GetComponent<EnemyStoreVariables>().gun1;
        gun2 = GetComponent<EnemyStoreVariables>().gun2;
        gun3 = GetComponent<EnemyStoreVariables>().gun3;

        lookAtPoint = transform.FindChild("LookAtPoint");
    }

    private void Start()
    {
        enemyZClamp = Random.Range(700f, 1000f);
        enemyXPos = Random.Range(-250f, 250f);
        lerpSpeed = Random.Range(0.25f, 1f);
        maneuverRadius = Random.Range(maneuverRadiusMin, maneuverRadiusMax);

        player = GameObject.Find("Player");
        playerTarget = GameObject.Find("PlayerTarget");
        //MoveOrder(player.transform.position);
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        startManeuver = true;
        hasChosenDirection = false;
        hasChosenAction = false;

        //transform.FindChild("Gun1").GetComponent<Enemy1Fire>().fireFreq = transform.FindChild("Gun1").GetComponent<Enemy1Fire>().startFireFreq;
        //transform.FindChild("Gun2").GetComponent<Enemy1Fire>().fireFreq = transform.FindChild("Gun2").GetComponent<Enemy1Fire>().startFireFreq;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (player.transform.position.z + enemyZClamp >= transform.position.z)      //if enemy is near player
        {
            if (!hasChosenAction)
            {
                hasChosenAction = true;
                randomInt = Random.Range(0, 2);

                if (randomInt == 0)
                {
                    ChangeState(State.MANEUVER);
                }
                else //if (randomInt == 1)
                {
                    ChangeState(State.STRAFE);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (maneuverTimer >= ((5 * Mathf.PI) / 3))
        {
            ChangeState(State.MOVING);
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

                    if (ceasedFire)
                    {
                        ceasedFire = false;
                        gun1.GetComponent<Enemy1Fire>().canFire = true;
                        gun2.GetComponent<Enemy1Fire>().canFire = true;
                        gun3.GetComponent<Enemy1Fire>().canFire = false;
                    }

                    transform.LookAt(playerTarget.transform);

                    transform.Translate(Vector3.forward * speed * Time.deltaTime);

                    //if (elapsedTime > checkTime)
                    //{
                    //    checkTime = elapsedTime + 1;
                    //    SetTarget();
                    //}

                    //if (path != null)
                    //{
                    //    if (onNode)
                    //    {
                    //        onNode = false;
                    //        if (nodeIndex < path.Count)
                    //            currNode = path[nodeIndex];
                    //    }
                    //    else
                    //        MoveToward();
                    //}
                    break;

                case State.MANEUVER:
                    OldTime = elapsedTime + 0.01f;

                    if (!ceasedFire)
                    {
                        ceasedFire = true;
                        gun1.GetComponent<Enemy1Fire>().canFire = false;
                        gun2.GetComponent<Enemy1Fire>().canFire = false;
                        gun3.GetComponent<Enemy1Fire>().canFire = true;
                    }

                    transform.LookAt(lookAtPoint);

                    maneuverTimer += Time.deltaTime;
                    maneuverAngle = maneuverTimer;

                    centerX += player.transform.position.x;
                    centerY += player.transform.position.y;
                    centerZ += player.transform.position.z;

                    if (transform.position.x > player.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = false;
                    }
                    else if (transform.position.x < player.transform.position.x && !hasChosenDirection)
                    {
                        hasChosenDirection = true;
                        maneuverLeft = true;
                    }

                    if (maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(-centerX + (Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the left of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * 2.5f);
                    }
                    else if (!maneuverLeft && hasChosenDirection)
                    {
                        lookAtPoint.position = new Vector3(centerX + -(Mathf.Cos(maneuverAngle) * maneuverRadius), centerY, centerZ + -(Mathf.Sin(maneuverAngle) * (maneuverRadius * 3)));
                        //Maneuver to the right of the player
                        transform.position = Vector3.Lerp(transform.position, lookAtPoint.position, Time.deltaTime * 2.5f);
                    }

                    centerX = _centerX;
                    centerY = _centerY;
                    centerZ = _centerZ;

                    break;

                case State.STRAFE:
                    OldTime = elapsedTime + 0.01f;

                    if (transform.position.x < player.transform.position.x && transform.position.y < player.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-100f, -100f, -1000f), Time.deltaTime * 7f);
                    }
                    else if (transform.position.x < player.transform.position.x && transform.position.y > player.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-100f, 100f, -1000f), Time.deltaTime * 7f);
                    }
                    else if (transform.position.x > player.transform.position.x && transform.position.y > player.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(100f, 100f, -1000f), Time.deltaTime * 7f);
                    }
                    else if (transform.position.x > player.transform.position.x && transform.position.y < player.transform.position.y)
                    {
                        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(100f, -100f, -1000f), Time.deltaTime * 7f);
                    }

                    if (transform.position.z > player.transform.position.z + 400)
                    {
                        transform.LookAt(playerTarget.transform);
                        gun3.transform.LookAt(playerTarget.transform);
                        gun1.GetComponent<Enemy1Fire>().fireFreq = 0.5f;
                        gun2.GetComponent<Enemy1Fire>().fireFreq = 0.5f;
                        gun3.GetComponent<Enemy1Fire>().canFire = true;
                        gun3.GetComponent<Enemy1Fire>().fireFreq = 0.25f;
                    }
                    else if (transform.position.z <= player.transform.position.z + 400)
                    {
                        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                        gun3.transform.LookAt(playerTarget.transform);

                        if (transform.position.z < player.transform.position.z - 350)
                        {
                            _waveHandler.enemyCount--;
                            gameObject.SetActive(false);
                        }
                    }

                    break;

                //case State.ATTACK:
                //    OldTime = elapsedTime + 0.01f;

                //    transform.LookAt(player.transform);

                //    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + enemyXPos, player.transform.position.y, player.transform.position.z + enemyZClamp), Time.deltaTime * lerpSpeed);
                //    break;
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
        newPos += motion * (speed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
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