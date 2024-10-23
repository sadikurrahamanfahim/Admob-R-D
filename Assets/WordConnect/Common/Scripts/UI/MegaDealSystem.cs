using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaDealSystem : MonoBehaviour
{
    public static int isMegaDealOpen;
    public GameObject objectToActivate;

    private void Awake()
    {
        isMegaDealOpen = PlayerPrefs.GetInt("isMegaDealOpen");
    }

    private void Start()
    {
        Debug.Log(isMegaDealOpen);
    }

    private void Update()
    {
        if (isMegaDealOpen == 0)
        {
            // Set the GameObject active
            objectToActivate.SetActive(false);
        }
        else if (isMegaDealOpen > 0)
        {
            // Log a warning if the GameObject is not found
            objectToActivate.SetActive(true);
        }
    }

    public void MegaDealClose()
    {
        PlayerPrefs.SetInt("isMegaDealOpen", isMegaDealOpen = 0);
    }
}
