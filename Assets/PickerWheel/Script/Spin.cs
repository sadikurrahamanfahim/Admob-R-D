using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI ;
using TMPro;

public class Spin : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private Button uiCloseButton; // Added close button
    [SerializeField] private TextMeshProUGUI uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;
    [SerializeField] private AudioSource audioSummiter;

    private int amount = 0;

    public GameObject Spinbtn;
    public GameObject SpinAgain;
    public GameObject Collect;

    public string Wheel = "Wheel";

    private void OnEnable()
    {
        // Enable the spin button based on PlayerPrefs value
        bool canSpin = PlayerPrefs.GetInt("HasClaimedKeyForSpin", 0) == 0;
        uiSpinButton.interactable = canSpin;
        uiSpinButtonText.text = canSpin ? "Spin" : "Spinning";
    }

    private void Start()
    {
        Spinbtn.SetActive(true);
        SpinAgain.SetActive(false);
        Collect.SetActive(false);

        uiSpinButton.onClick.AddListener(() =>
        {
            int hasClaimedForSpin = PlayerPrefs.GetInt("HasClaimedKeyForSpin");

            if (hasClaimedForSpin == 0)
            {
                uiSpinButton.interactable = false;
                uiSpinButtonText.text = "Spinning";

                pickerWheel.OnSpinStart(() =>
                {
                    // Debug.Log("Spin Start");
                });

                pickerWheel.OnSpinEnd(wheelPiece =>
                {
                    // Debug.Log("End Spin" + wheelPiece.Label + ", Amount " + wheelPiece.Amount);
                    uiSpinButton.interactable = true;
                    audioSummiter.Play();
                    uiSpinButtonText.text = "Spin";

                    Spinbtn.SetActive(false);
                    SpinAgain.SetActive(true);
                    Collect.SetActive(true);

                    if (wheelPiece.Label == "x2")
                    {
                        amount = 2;
                    }

                    if (wheelPiece.Label == "x35")
                    {
                        amount = 35;
                    }

                    if (wheelPiece.Label == "x15")
                    {
                        amount = 15;
                    }

                    if (wheelPiece.Label == "x30")
                    {
                        amount = 30;
                    }

                    if (wheelPiece.Label == "x5")
                    {
                        amount = 5;
                    }

                    if (wheelPiece.Label == "x20")
                    {
                        amount = 20;
                    }

                    if (wheelPiece.Label == "x10")
                    {
                        amount = 10;
                    }

                    if (wheelPiece.Label == "x50")
                    {
                        amount = 50;
                    }

                    // Mark that the spin has been claimed
                });

                pickerWheel.Spin();
            }
        });
    }

    public void ClaimAndCloseWheel()
    {
        GameObject wheel = GameObject.Find(Wheel);

        if (wheel != null)
        {
            // Set the GameObject active
            wheel.SetActive(false);
        }
        CoinAnim.Instance.StartCoinAnimation(amount, Collect.transform.position, false);
        PlayerPrefs.SetInt("HasClaimedKeyForSpin", DailySpin.HasClaimedKeyForSpin = 1);
    }
    
    public void CloseWheel()
    {
        GameObject wheel = GameObject.Find(Wheel);

        if (wheel != null)
        {
            // Set the GameObject active
            wheel.SetActive(false);
        }
    }
}