using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCountrySelect : MonoBehaviour
{
    public Button CountryButton_CN;
    public Button CountryButton_BN;
    public Button CountryButton_BD;
    public Button CountryButton_PK;
    public Button CountryButton_AE;
    public Button CountryButton_SA;
    public Button CountryButton_EG;
    public Button CountryButton_FR;
    public Button CountryButton_EN;
    public Button CountryButton_BR;
    public Button ExitButton;

    void Start()
    {
        ExitButton.onClick.AddListener(OnClickExitButton);
    }

    void Update()
    {
        
    }

    private void OnClickExitButton()
    {
        GameObject.Destroy(this.gameObject);
    }
}
