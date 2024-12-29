using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public Text RecordedTime;
    public Button RecordStart;
    public Button RecordStop;
    public Button IntervalRecord;
    private string Timestring;
    private float time = 0f;
    private bool IsStarted;

    void Start()
    {
        RecordStart.onClick.AddListener(OnClickRecordStart);
        RecordStop.onClick.AddListener(OnClickRecordStop);
        IntervalRecord.onClick.AddListener(OnClickInervalRecord);
    }

    void Update()
    {
        if (IsStarted)
        {
            time += Time.deltaTime;
            Timestring = Math.Round(time, 2).ToString();
            RecordedTime.text = Timestring.Replace('.',':');
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
        // Todo: 버튼을 눌렀을 때 현재 time을 기록해서 남기기
    }
}
