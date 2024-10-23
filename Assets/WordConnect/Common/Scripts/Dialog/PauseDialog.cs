using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PauseDialog : Dialog {

    protected override void Start()
    {
        base.Start();
    }

    public void OnContinueClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        CUtils.LoadScene(1, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHomeClick()
    {
        CUtils.LoadScene(0, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnRateClick()
    {
#if UNITY_IOS || UNITY_IPHONE
        Application.OpenURL("https://www.apple.com/app-store/");
#elif UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier);
#endif
        Sound.instance.PlayButton();
        Close();
    }

    public void OnMoreGameClick()
    {
        Application.OpenURL("https://www.apple.com/app-store/");
        Sound.instance.PlayButton();
        Close();
    }
    public void OnPolyciClick()
    {
        Application.OpenURL("https://sites.google.com/view/abcgamesstudioprivacypolicy/home");
        Sound.instance.PlayButton();
        Close();
    }
    public void OnShareClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHowToPlayClick()
    {
        Sound.instance.PlayButton();
        DialogController.instance.ShowDialog(DialogType.HowtoPlay);
    }

    public void ContactUs()
    {
        string email = "nihalhammad06292020@gmail.com";
        string subject = MyEscapeURL("Need support from the developer");
        string body = MyEscapeURL("");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    
    string MyEscapeURL (string url)
    {
        return UnityWebRequest.EscapeURL(url).Replace("+","%20");
    }
}
