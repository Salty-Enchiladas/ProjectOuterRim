using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitialWrangler : MonoBehaviour {

    public char[] possibleInitials = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    //, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    int currentCharacter;

    public int CurrentCharacter
    {
        get { return currentCharacter; }
    }

    public void NextCharacter()
    {
        if (currentCharacter == possibleInitials.Length - 1)
        {
            currentCharacter = 0;
        }
        else
        {
            currentCharacter++;
        }

        UpdateText();
    }

    public void PreviousCharacter()
    {
        if (currentCharacter == 0)
        {
            currentCharacter = possibleInitials.Length - 1;
        }
        else
        {
            currentCharacter--;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        if (gameObject.GetComponent<Text>())
        {
            gameObject.GetComponent<Text>().text = possibleInitials[currentCharacter].ToString();
        }
    }
}
