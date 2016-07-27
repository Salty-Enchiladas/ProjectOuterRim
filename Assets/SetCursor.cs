using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour 
{
 
//****** You can donate directly to Jesse through paypal at  https://www.paypal.me/JEtzler   ******

public Texture2D yourCursor;  // Your cursor texture
int cursorSizeX = 16;  // Your cursor size x
int cursorSizeY = 16;  // Your cursor size y

void Start()
{
    Cursor.visible = false;
}

void OnGUI()
{
    GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), yourCursor);
}
}

