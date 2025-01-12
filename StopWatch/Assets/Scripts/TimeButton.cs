using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public Text TimeText;
    public Text RecordedTime;
    public Button RecordStart;
    public Button RecordStop;
    public Button IntervalRecord;
    public Button RecordClear;
    private string Timestring;
    private float time = 0f;
    private bool IsStarted;

    void Start()
    {
        RecordStart.onClick.AddListener(OnClickRecordStart);
        RecordStop.onClick.AddListener(OnClickRecordStop);
        IntervalRecord.onClick.AddListener(OnClickInervalRecord);
        RecordClear.onClick.AddListener(OnClickRecordClear);
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

    private void OnClickRecordStart()
    {
        IsStarted = true;
        ButtonActivateUpdate();
    }
    private void OnClickRecordStop()
    {
        IsStarted = false;
        ButtonActivateUpdate();
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
    private void ButtonActivateUpdate()
    {
        RecordStart.gameObject.SetActive(!IsStarted);
        RecordStop.gameObject.SetActive(IsStarted);
    }

}
