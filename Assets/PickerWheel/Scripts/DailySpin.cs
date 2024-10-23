using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DailySpin : MonoBehaviour
{
    // Key to store whether the reward has been claimed on the current day
    public static int HasClaimedKeyForSpin;
    private const string LastResetDateKey = "LastResetDate";

    // Reward button in the Unity Editor
    public GameObject SpinWheelGame;

    public string DailyBonus = "Daily Bonus";

    private void Start()
    {
        HasClaimedKeyForSpin = PlayerPrefs.GetInt("HasClaimedKeyForSpin");
        // Check the current claimed status for the day and update UI accordingly
        if (HasClaimedKeyForSpin == 0)
        {
            //UpdateUI(); // here is function to enable daily spin
        }

        CheckDailyReset();
    }
    public void OnRewardButtonClick()
    {
        SpinWheelGame.SetActive(true);
    }

    public void ResetReward()
    {
        // Reset the claimed status for the current day
        PlayerPrefs.SetInt("HasClaimedKeyForSpin", HasClaimedKeyForSpin = 0);
    }

    private void CheckDailyReset()
    {
        // Check if it's a new day
        DateTime lastResetDate = DateTime.ParseExact(PlayerPrefs.GetString(LastResetDateKey, DateTime.UtcNow.ToString("yyyy-MM-dd")), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime currentDateTime = DateTime.UtcNow;

        if (currentDateTime.Date > lastResetDate.Date)
        {
            // It's a new day, reset HasClaimedKeyForSpin
            PlayerPrefs.SetInt("HasClaimedKeyForSpin", HasClaimedKeyForSpin = 0);

            // Update LastResetDate to the current date
            PlayerPrefs.SetString(LastResetDateKey, currentDateTime.ToString("yyyy-MM-dd"));
        }
    }

    private void UpdateUI()
    {
        GameObject dailyBonus = GameObject.Find(DailyBonus);

        // Check if the GameObject is found
        if (dailyBonus != null || HasClaimedKeyForSpin == 1)
        {
            // Set the GameObject active
            SpinWheelGame.SetActive(false);
        }
        else if (dailyBonus == null || HasClaimedKeyForSpin == 0)
        {
            SpinWheelGame.SetActive(true);
        }
    }
}
