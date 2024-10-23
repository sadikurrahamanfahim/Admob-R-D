using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Daily7DaysLogin : MonoBehaviour
{
    // Key to store whether the reward has been claimed on the current day
    public static int HasClaimfor7DaysLogin;
    public static int OpenAmount;
    private const string SaveAlreadyClaimAmount = "SaveAlreadyClaimAmount";

    // Reward button in the Unity Editor
    public GameObject DailyCheckInPanel;
    public bool isClaim;
    public bool isOpen;

    public GameObject Day1;
    public GameObject Day2;
    public GameObject Day3;
    public GameObject Day4;
    public GameObject Day5;
    public GameObject Day6;
    public GameObject Day7;

    public GameObject Day1Real;
    public GameObject Day2Real;
    public GameObject Day3Real;
    public GameObject Day4Real;
    public GameObject Day5Real;
    public GameObject Day6Real;
    public GameObject Day7Real;


    public void Awake()
    {
        HasClaimfor7DaysLogin = PlayerPrefs.GetInt("HasClaimfor7DaysLogin");
        OpenAmount = PlayerPrefs.GetInt("OpenAmount");
    }

    private void Start()
    {
        if (OpenAmount == 0)
        {
            isOpen = false;
        }
        else if (OpenAmount >= 1)
        {
            isOpen = true;
        }

        UpdateUI();
    }

    private void FixedUpdate()
    {
        if (HasClaimfor7DaysLogin == 0)
        {
            isClaim = false;
        }


        if (!isOpen)
        {
            DailyCheckInPanel.SetActive(true);
        }

        CheckDailyReset();
    }

    private void CheckDailyReset()
    {
        // Check if it's a new day
        DateTime lastResetDate = DateTime.ParseExact(PlayerPrefs.GetString(SaveAlreadyClaimAmount, DateTime.UtcNow.ToString("yyyy-MM-dd")), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime currentDateTime = DateTime.UtcNow;

        if (currentDateTime.Date > lastResetDate.Date)
        {
            // It's a new day, reset HasClaimedKeyForSpin
            PlayerPrefs.SetInt("HasClaimfor7DaysLogin", HasClaimfor7DaysLogin += 1);

            PlayerPrefs.SetInt("OpenAmount", OpenAmount = 0);

            isClaim = false;

            // Update LastResetDate to the current date
            PlayerPrefs.SetString(SaveAlreadyClaimAmount, currentDateTime.ToString("yyyy-MM-dd"));
        }
    }

    private void UpdateUI()
    {
        int hasClaimedForSpin = PlayerPrefs.GetInt("HasClaimfor7DaysLogin", HasClaimfor7DaysLogin);

        if (hasClaimedForSpin == 0 && !isClaim)
        {
            Day1.SetActive(true);
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day6.SetActive(false);
            Day7.SetActive(false);

            Day1Real.SetActive(false);
            Day2Real.SetActive(true);
            Day3Real.SetActive(true);
            Day4Real.SetActive(true);
            Day5Real.SetActive(true);
            Day6Real.SetActive(true);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 1 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(true);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day6.SetActive(false);
            Day7.SetActive(false);

            Day1Real.SetActive(true);
            Day2Real.SetActive(false);
            Day3Real.SetActive(true);
            Day4Real.SetActive(true);
            Day5Real.SetActive(true);
            Day6Real.SetActive(true);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 2 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(true);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day6.SetActive(false);
            Day7.SetActive(false);

            Day1Real.SetActive(true);
            Day2Real.SetActive(true);
            Day3Real.SetActive(false);
            Day4Real.SetActive(true);
            Day5Real.SetActive(true);
            Day6Real.SetActive(true);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 3 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(true);
            Day5.SetActive(false);
            Day6.SetActive(false);
            Day7.SetActive(false);

            Day1Real.SetActive(true);
            Day2Real.SetActive(true);
            Day3Real.SetActive(true);
            Day4Real.SetActive(false);
            Day5Real.SetActive(true);
            Day6Real.SetActive(true);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 4 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(true);
            Day6.SetActive(false);
            Day7.SetActive(false);

            Day1Real.SetActive(true);
            Day2Real.SetActive(true);
            Day3Real.SetActive(true);
            Day4Real.SetActive(true);
            Day5Real.SetActive(false);
            Day6Real.SetActive(true);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 5 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day6.SetActive(true);
            Day7.SetActive(false);

            Day1Real.SetActive(true);
            Day2Real.SetActive(true);
            Day3Real.SetActive(true);
            Day4Real.SetActive(true);
            Day5Real.SetActive(true);
            Day6Real.SetActive(false);
            Day7Real.SetActive(true);

            isClaim = true;
        }
        else if (hasClaimedForSpin == 6 && !isClaim)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day6.SetActive(false);
            Day7.SetActive(true);

            Day1Real.SetActive(true);
            Day2Real.SetActive(true);
            Day3Real.SetActive(true);
            Day4Real.SetActive(true);
            Day5Real.SetActive(true);
            Day6Real.SetActive(true);
            Day7Real.SetActive(false);

            isClaim = true;
        }
    }

    public void ClaimDaily()
    {
        PlayerPrefs.SetInt("OpenAmount", OpenAmount += 1);

        if (Day1.activeSelf)
        {
            CurrencyController.CreditBalance(5);
            Day1.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if (Day2.activeSelf)
        {
            CurrencyController.CreditBalance(10);
            Day2.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if(Day3.activeSelf)
        {
            CurrencyController.CreditBalance(15);
            Day3.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if(Day4.activeSelf)
        {
            CurrencyController.CreditBalance(20);
            Day4.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if(Day5.activeSelf)
        {
            CurrencyController.CreditBalance(25);
            Day5.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if(Day6.activeSelf)
        {
            CurrencyController.CreditBalance(30);
            Day6.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
        else if(Day7.activeSelf)
        {
            CurrencyController.CreditBalance(35);
            Day7.SetActive(false);

            DailyCheckInPanel.SetActive(false);

            isOpen = true;
        }
    }
}
