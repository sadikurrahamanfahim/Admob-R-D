using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UI.Dates;
using UnityEngine.UI;
using Animation = UI.Dates.Animation;

public class DailyChallenge : Dialog
{
    public DatePicker datePicker;
    private int stars;
    [SerializeField] private Slider slider;
    [SerializeField] private Image[] lightImages, boxes;
    [SerializeField] private Text[] texts;
    [SerializeField] private Animator[] animations;
    [SerializeField] private Sprite[] collectedSprites;
    [SerializeField] private Text headerText, instText;
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] coinAmount;
    private int[] coin = new []{30,50,100,120,150};
    [SerializeField] Ease easeType;
    protected override void Start()
    {
        base.Start();
        DateTime dt = DateTime.Now;
        headerText.text = $"{dt:MMM} Bonus";
        instText.text = $"Collect stars to win the bonus of {dt:MMM}.";
        int date = CPlayerPrefs.GetInt("date");
        if (date == 0) CPlayerPrefs.SetInt("date", dt.Day);
        if (date != dt.Day)
        {
            ResetData();
            CPlayerPrefs.SetInt("date", dt.Day);
        }
        datePicker.enabled = true;
        datePicker.UpdateDisplay();
        StarCount();
    }

    private void StarCount()
    {
        stars = CPlayerPrefs.GetInt("star_count");
        SetUI();
    }

    private void SetUI()
    {
        slider.value = stars;
        if (stars >= 1)
        {
            if (!CPlayerPrefs.GetBool("box0"))
            {
                lightImages[0].gameObject.SetActive(true);
                animations[0].enabled = true;
                buttons[0].interactable = true;
            }
            else
            {
                boxes[0].sprite = collectedSprites[0];
                buttons[0].interactable = false;
            }
            texts[0].gameObject.SetActive(true);
            if (stars > 1)
            {
                texts[1].gameObject.SetActive(true);
                texts[1].text = $"{Mathf.Clamp(stars, 1, 6)}/6";
            }
        }
        if (stars >= 6)
        {
            if (!CPlayerPrefs.GetBool("box1"))
            {
                lightImages[1].gameObject.SetActive(true);
                animations[1].enabled = true;
                buttons[1].interactable = true;
            }
            else
            {
                boxes[1].sprite = collectedSprites[1];
                buttons[1].interactable = false;
            }
            if (stars > 6)
            {
                texts[2].gameObject.SetActive(true);
                texts[2].text = $"{Mathf.Clamp(stars, 1, 15)}/15";
            }
        }
        if (stars >= 15)
        {
            if (!CPlayerPrefs.GetBool("box2"))
            {
                lightImages[2].gameObject.SetActive(true);
                animations[2].enabled = true;
                buttons[2].interactable = true;
            }
            else
            {
                boxes[2].sprite = collectedSprites[2];
                buttons[2].interactable = false;
            }
            if (stars > 15)
            {
                texts[3].gameObject.SetActive(true);
                texts[3].text = $"{Mathf.Clamp(stars, 1, 25)}/25";
            }
        }
        if (stars >= 25)
        {
            if (!CPlayerPrefs.GetBool("box3"))
            {
                lightImages[3].gameObject.SetActive(true);
                animations[3].enabled = true;
                buttons[3].interactable = true;
            }
            else
            {
                boxes[3].sprite = collectedSprites[3];
                buttons[3].interactable = false;
            }
            if (stars > 25)
            {
                texts[4].gameObject.SetActive(true);
                texts[4].text = $"{Mathf.Clamp(stars, 1, 38)}/38";
            }
        }
        if (stars >= 38)
        {
            if (!CPlayerPrefs.GetBool("box4"))
            {
                lightImages[4].gameObject.SetActive(true);
                animations[4].enabled = true;
                buttons[4].interactable = true;
            }
            else
            {
                boxes[4].sprite = collectedSprites[4];
                buttons[4].interactable = false;
            }
        }
    }

    public void ButtonAction(int value)
    {
        if (CPlayerPrefs.GetBool($"box{value}")) return;
        CPlayerPrefs.SetBool($"box{value}", true);
        lightImages[value].gameObject.SetActive(false);
        animations[value].enabled = false;
        boxes[value].sprite = collectedSprites[value];
        Animate(coinAmount[value], coin[value]);
    }
    
    void Animate (GameObject coin, int amount)
    {
        CurrencyController.CreditBalance(amount);
        coin.SetActive (true);
        coin.transform.DOScale(new Vector3(2, 2, 2), 1.5f);
        coin.transform.DOMove (Vector2.up, 1.5f)
            .SetEase (easeType)
            .OnComplete (() => {
                coin.SetActive (false);
            });
    }

    private void ResetData()
    {
        for (int i = 0; i < 5; i++) CPlayerPrefs.SetBool($"box{i}", false);
        slider.value = 0;
        CPlayerPrefs.SetInt("star_count", 0);
    }
}
