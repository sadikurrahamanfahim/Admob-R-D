using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dotMob;

public class MainController : BaseController {
    public Text levelNameText;

    private int world, subWorld, level;
    private bool isGameComplete;
    private GameLevel gameLevel;

    public static MainController instance;

    public ThemeItem redTheme;
    public ThemeItem greenTheme;
    private int themeIndex;
    public Image downBg, leftButtonBg, rightButtonBg, hints, hintsBg, leafLeft, leafRight, replay, starButton, topBg;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        world = GameState.currentWorld;
        subWorld = GameState.currentSubWorld;
        level = GameState.currentLevel;
        //world = Prefs.unlockedWorld;
        //subWorld = Prefs.unlockedSubWorld;
        //level = Prefs.unlockedLevel;
        //Debug.Log("word :" + world.ToString());
        //Debug.Log("subWorld :" + subWorld.ToString());

        //Debug.Log("level :" + level.ToString());
        gameLevel = Utils.Load(world, subWorld, level);
        Pan.instance.Load(gameLevel);
        WordRegion.instance.Load(gameLevel);
        SelectedTheme();
        
        if (world == 0 && subWorld == 0 && level == 0)
        {
            Timer.Schedule(this, 0.5f, () =>
            {
                DialogController.instance.ShowDialog(DialogType.HowtoPlay);
            });
        }

        levelNameText.text = "Level " + (level + 1);
    }

    public void SelectedTheme()
    {
        themeIndex = CPlayerPrefs.GetInt("selected_theme");
        SetTheme(themeIndex == 0 ? redTheme : greenTheme);
    }

    private void SetTheme(ThemeItem item)
    {
        downBg.sprite = item.downBg;
        leftButtonBg.sprite = rightButtonBg.sprite = item.buttonBg;
        hints.sprite = item.hints;
        hintsBg.sprite = item.hintsBg;
        leafLeft.sprite = item.leafLeft;
        leafRight.sprite = item.leafRight;
        replay.sprite = item.replay;
        starButton.sprite = item.starButton;
        topBg.sprite = item.topBg;
    }

    public void OnComplete()
    {
        if (isGameComplete) return;
        isGameComplete = true;
        //show win
        // Debug.Log("SHOW WIN");
        int ran = Random.Range(0, 2);
        // Debug.Log("Random :" + ran);
        Timer.Schedule(this, 1f, () =>
        {
            if(ran == 0 || ran == 2)
            {
                CUtils.ShowInterstitialAd();
            }
            
            //Ad 2 coin when level complete
            CurrencyController.CreditBalance(2);
            DialogController.instance.ShowDialog(DialogType.Win);
            Sound.instance.Play(Sound.Others.Win);
        });
        int stars = CPlayerPrefs.GetInt("star_count");
        CPlayerPrefs.SetInt("star_count", stars+1);
    }

    private string BuildLevelName()
    {
        return world + "-" + subWorld + "-" + level;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogController.instance.IsDialogShowing())
        {
            DialogController.instance.ShowDialog(DialogType.Pause);
        }
    }
}
