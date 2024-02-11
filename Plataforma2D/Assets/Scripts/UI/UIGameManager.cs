using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIGameManager : Singleton<UIGameManager>
{
    public TextMeshProUGUI uiTextCoins;


    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
}
