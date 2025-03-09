using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountrySlot : MonoBehaviour
{
    public Button CountrySlotButton;
    public Text CountryNameText;
    public Text TimeDiffText;
    string CountryName;
    string TimeDiffString;
    int TimeDiff;

    void Start()
    {
        CountrySlotButton = GetComponent<Button>();
        CountryName = CountryNameText.text;
        TimeDiffString = TimeDiffText.text;
        TimeDiffString = TimeDiffString.Split()[1];
        TimeDiffString = TimeDiffString.Split("시")[0];
        TimeDiff = int.Parse(TimeDiffString);

        CountrySlotButton.onClick.AddListener(OnClickCountrySlotButton);
    }

    private void OnClickCountrySlotButton()
    {
        // GlobalTimeSlot 슬롯 scrollview content에 생성
        // 국가 리스트 팝업창이 꺼짐 (PopupCountrySelect)
        FindObjectOfType<GlobalTimeCanvas>().InstantiateSlot(CountryName, TimeDiff);
        FindObjectOfType<PopupCountrySelect>().OnClickExitButton();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
