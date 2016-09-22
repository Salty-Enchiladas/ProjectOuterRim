using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CursorMovement : MonoBehaviour {

    public EventSystem eventSystem;
    public float speed;

    float moveX;
    float moveY;

    bool isCursorOver;

    Camera mainCam;

    GameObject currentButton;

    string[] joysticks;    

	// Use this for initialization
	void Start () {
        joysticks = Input.GetJoystickNames();
        mainCam = Camera.main;        
	}

    // Update is called once per frame
    void Update()
    {
        joysticks = Input.GetJoystickNames();

        MoveCursor();

        if (Input.GetButtonUp("Submit"))        // || Input.GetMouseButtonUp(0)
        {
            Click();
        }

        //OnCursorExit(currentButton);

        //Ray ray = Camera.main.ScreenPointToRay(transform.position);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.collider.tag == "Button")
        //    {
        //        currentButton = hit.collider.gameObject;
                
        //        OnCursorOver(currentButton);

        //        if (Input.GetButtonUp("Submit") || Input.GetMouseButtonUp(0))
        //        {
        //            Click();
        //        }
        //    }
        //}
	}

    void MoveCursor()
    {
        if (joysticks.Length > 0)
        {
            if (joysticks[0] != "")
            {
                moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

                transform.position += new Vector3(moveX, moveY, 0f);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, Screen.width), Mathf.Clamp(transform.position.y, 0, Screen.height), mainCam.nearClipPlane);
            }
            else if (joysticks[0] == "")
            {
                transform.position = Input.mousePosition;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, Screen.width), Mathf.Clamp(transform.position.y, 0, Screen.height), mainCam.nearClipPlane);
            }
        }
        else
        {
            transform.position = Input.mousePosition;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, Screen.width), Mathf.Clamp(transform.position.y, 0, Screen.height), mainCam.nearClipPlane);
        }
    }

    void Click()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero);

        if (hit.collider.tag == "Button")
        {
            ExecuteEvents.Execute(hit.collider.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
        }
        else
        {
            //do nothing
        }

        //Ray ray = Camera.main.ScreenPointToRay(transform.position);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.collider == null)
        //    {
        //        return;
        //    }
        //    else if (hit.collider.tag == "Button")
        //    {
        //        hit.collider.gameObject.GetComponent<IsButton>().ButtonFunction();


        //        //ExecuteEvents.Execute(hit.collider.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
        //    }
        //}
    }

    void OnCursorOver(GameObject button)
    {
        if (!isCursorOver)
        {
            isCursorOver = true;
            button.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
    }

    void OnCursorExit(GameObject button)
    {
        if (isCursorOver)
        {
            isCursorOver = false;
            button.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }
}
