using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public int coin, target;
    public Slider slide;
    public Button button;
    public Text text;
    [SerializeField] private string itemCollected;

    public void SliderListener(float value)
    {
        button.gameObject.SetActive(value >= target);
        text.text = $"{value}/{target}";

        if (!CPlayerPrefs.GetBool(itemCollected))return;
        button.interactable = false;
        var colors = button.colors;
        colors.normalColor = Color.grey;
        button.colors = colors;
    }

    public void Collect()
    {
        CurrencyController.CreditBalance(coin);
        button.interactable = false;
        CPlayerPrefs.SetBool(itemCollected, true);
    }
}
