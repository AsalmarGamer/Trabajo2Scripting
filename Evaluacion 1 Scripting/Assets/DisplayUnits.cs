using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayUnits : MonoBehaviour
{
    public Units unit;

    public TextMeshProUGUI TextName;
    public Image DisplaySprite;

    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;

    public TextMeshProUGUI PaText;
    public TextMeshProUGUI PmText;

    private void Start()
    {
        TextName.text = unit.name;
        DisplaySprite.sprite = unit._sprite;

        HpText.text = unit.HP.ToString();
        AtkText.text = unit.AtkPoints.ToString();
        DefText.text = unit.DefPoints.ToString();

        PaText.text = unit.PA.ToString();
        PmText.text = unit.PM.ToString();
    }

    public void UpdateDisplay()
    {
        DisplaySprite.sprite = unit._sprite;

        HpText.text = unit.HP.ToString();
        AtkText.text = unit.AtkPoints.ToString();
        DefText.text = unit.DefPoints.ToString();

        PaText.text = unit.PA.ToString();
        PmText.text = unit.PM.ToString();
    }
}
