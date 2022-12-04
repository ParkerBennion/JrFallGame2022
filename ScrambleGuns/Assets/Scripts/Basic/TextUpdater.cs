using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string preString;

    public string postString;
    // Start is called before the first frame update


    public void RefreshText(SO_IntList number)
    {
        text.text = preString + (" ") + number.lastInt + (" ") + postString;
    }
    public void RefreshText(So_HighScore number)
    {
        text.text = preString + (" ") + number.highScore + (" ") + postString;
    }
}
