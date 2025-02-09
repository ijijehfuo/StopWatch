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
    
    public Text TimeText;
    public Text RecordedTime;
    public Button LeftButton;
    public Text LeftButtonTxt;
    public Button RightButton;
    public Text RightButtonTxt;
    public ScrollRect ScrollRect;
    private string Timestring;
    private float time = 0f;
    private bool IsStarted;
    
    void Start()
    {
        
        UpdateUI(Phase.start);
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

    private void UpdateUI(Phase StopWatchPhase)
    {
        switch(StopWatchPhase)
        {
            case Phase.start:
                // 앱 최초진입시 설정
                UpdateButtonText("Start", "Record");
                UpdateButtonColor(Color.blue, Color.gray);
                ResetListeners();
                RightButton.onClick.AddListener(OnClickRecordStart);
                break;
            case Phase.AfterPressingStartBtn:
                //Todo: rightbutton: start->stop, stop누르면 시간멈춤, record addlistener, record 누르면 기록 추가
                UpdateButtonText("Stop", "Record");
                UpdateButtonColor(Color.red, Color.white);
                ResetListeners();
                RightButton.onClick.AddListener(OnClickRecordStop);
                LeftButton.onClick.AddListener(OnClickIntervalRecord);
                break;
            case Phase.AfterPressingStopBtn:
                //Todo: RightButton: stop->Continue, LeftButton: Record-> Reset
                UpdateButtonText("Continue", "Reset");
                UpdateButtonColor(Color.blue, Color.white);
                ResetListeners();
                RightButton.onClick.AddListener(OnClickContinueRecord);
                LeftButton.onClick.AddListener(OnClickRecordClear);
                break;

        }
    }
    private void OnClickRecordStart()
    {
        UpdateUI(Phase.AfterPressingStartBtn);
        IsStarted = true;
    }
    private void OnClickRecordStop()
    {
        UpdateUI(Phase.AfterPressingStopBtn);
        IsStarted = false;
    }
    private void OnClickIntervalRecord()
    {
        RecordedTime.text += "\n" + TimeText.text;
        ScrollRect.verticalNormalizedPosition = 0f;
    }
    private void OnClickRecordClear()
    {
        IsStarted = false;
        UpdateUI(Phase.start);
        time = 0f;
        TimeText.text = "00:00.00";
        RecordedTime.text = "";
    }
    private void OnClickContinueRecord()
    {
        UpdateUI(Phase.AfterPressingStartBtn);
        IsStarted = true;
    }

    private void ResetListeners()
    {
        RightButton.onClick.RemoveAllListeners();
        LeftButton.onClick.RemoveAllListeners();
    }
    private void UpdateButtonColor(Color RightButtonColor, Color LeftButtonColor)
    {
        RightButton.GetComponent<Image>().color = RightButtonColor;
        LeftButton.GetComponent<Image>().color = LeftButtonColor;
    }
    private void UpdateButtonText(string RightButtonText, string LeftButtonText)
    {
        RightButtonTxt.text = RightButtonText;
        LeftButtonTxt.text = LeftButtonText;
    }

}
