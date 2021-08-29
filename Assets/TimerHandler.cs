using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerHandler : MonoBehaviour
{
    public Text TimerText;
    public int TimerForRoom;
    public bool TimeOver;
    public int TimeCounterLimit;
    public bool StartTimer;
    private float timeCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartTimer)
        {
            CountTime();
        }
    }

    public void CountTime()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter> TimeCounterLimit)
        {
            timeCounter = 0;
            TimerForRoom -= 1;
            TimerText.text = TimerForRoom.ToString();
            if(TimerForRoom<1)
            {
                //TimeOver = true;
                StartTimer = false;
            }
        }
    }
}
