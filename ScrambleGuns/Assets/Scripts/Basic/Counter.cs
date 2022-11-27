using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public bool gamePlay = false;
    public int time;
    private float ActualTime;
    private WaitForSeconds oneSec;
    void Start()
    {
        ActualTime = Time.time;
        time = 0;
        oneSec = new WaitForSeconds(1);
        TimerText.text = "0";
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (gamePlay)
        {
            time++;
            yield return oneSec;
            TimerText.text = time.ToString();
        }
    }

    public void StopTimer()
    {
        gamePlay = false;
    }
}
