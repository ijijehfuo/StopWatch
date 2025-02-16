using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GlobalTimePhase
{
    Main,
    SlotSelect,
}
public class GlobalTimeCanvas : MonoBehaviour
{
    // 맨위 text에 한국 표준시각, 아래 scrollview에 각 나라의 표준시각 슬롯 형태로 보여줌, +버튼 누르면 원하는 나라 슬롯에 추가
    public Text KoreanTimezoneText;
    public ScrollRect TimezoneList;
    public Button AddTimezoneButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KoreanTimezoneText.text = FormatCurrentSystemTime();
    }

    private string FormatCurrentSystemTime()
    {
        string result;
        DateTime now = DateTime.Now;
        if (now.Hour >= 12)
        {
            result = "<size=50>오후</size>";
            now.AddHours(-12);
        }
        else
        {
            result = "<size=50>오전</size>";
        }
        result += string.Format("{0:D2}:{1:D2}:{2:D2}", now.Hour, now.Minute, now.Second);
        return result;
    }

    private void UpdateUI(GlobalTimePhase Phase)
    {
        switch(Phase)
        {
            case GlobalTimePhase.Main:
                break;

            case GlobalTimePhase.SlotSelect:
                break;

        }
    }
}
