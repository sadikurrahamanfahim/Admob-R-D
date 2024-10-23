using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThemeDialog : Dialog
{

    public Button red, green;
    public Image redBorder, greenBorder;
    private int themeIndex;
    protected override void Start()
    {
        base.Start();
        themeIndex = CPlayerPrefs.GetInt("selected_theme");
        if (themeIndex == 0) RedTheme();
        else GreenTheme();
    }

    public void RedTheme()
    {
        greenBorder.gameObject.SetActive(false);
        redBorder.gameObject.SetActive(true);
        themeIndex = 0;
    }

    public void GreenTheme()
    {
        redBorder.gameObject.SetActive(false);
        greenBorder.gameObject.SetActive(true);
        themeIndex = 1;
    }

    public void SaveData()
    {
        CPlayerPrefs.SetInt("selected_theme", themeIndex);
        if (MainController.instance)
        {
            MainController.instance.SelectedTheme();
        }
    }
    
}
