using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase
{
    start=0,
    AfterPressingStartBtn,
    AfterPressingRecordBtn,
    AfterPressingStopBtn,
}

public class TimeButton : MonoBehaviour
{
    public Phase StopWatchPhase;
    public Text TimeText;
    public Text RecordedTime;
    public Button LeftButton;
    public Text LeftButtonTxt;
    public Button RightButton;
    public Text RightButtonTxt;
    private string Timestring;
    private float time = 0f;
    private bool IsStarted;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (IsStarted)
        {
            time += Time.deltaTime;
            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);
            int milliseconds = (int)((time * 100) % 100);

            TimeText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        }
    }

    private void UpdateUI()
    {
        switch(StopWatchPhase)
        {
            case Phase.start:
                RightButtonTxt.text = "Start";
                LeftButtonTxt.text = "Record";
                RightButton.onClick.RemoveAllListeners();
                LeftButton.onClick.RemoveAllListeners();
                RightButton.onClick.AddListener(OnClickRecordStart);
                break;
            case Phase.AfterPressingStartBtn:

                break;
            case Phase.AfterPressingRecordBtn:
                break;
            case Phase.AfterPressingStopBtn:
                break;

        }
    }
    private void OnClickRecordStart()
    {
        IsStarted = true;
    }
    private void OnClickRecordStop()
    {
        IsStarted = false;
    }
    private void OnClickInervalRecord()
    {
        RecordedTime.text += "\n" + TimeText.text;
    }
    private void OnClickRecordClear()
    {
        OnClickRecordStop();
        time = 0f;
        TimeText.text = "00:00.00";
        RecordedTime.text = "";
    }
    private void OnClickContinueRecord()
    {
        IsStarted = true;
    }

}
