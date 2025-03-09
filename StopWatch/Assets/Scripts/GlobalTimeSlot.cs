using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimeSlot : MonoBehaviour
{
    public Text CountryName;
    public Text TimeDiff;
    public Text CurrentTime;

    private void UpdateUI(string Countryname, int Timediff)
    {
        CountryName.text = Countryname;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
