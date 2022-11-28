using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseScript(int timeSpeed)
    {
        Time.timeScale = timeSpeed;
    }
}
