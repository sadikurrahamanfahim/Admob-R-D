using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievementDialog : Dialog
{
    [SerializeField] private AchievementItem[] items;
    private List<int> targets;

    protected override void Start()
    {
        base.Start();
        PrepareModal();
    }

    private void PrepareModal()
    {
        targets = new List<int>();
        int levels = 0;
        int unlockedWorld = Prefs.unlockedWorld;
        int unlockedSubWorld = Prefs.unlockedSubWorld;
        int unlockedLevel = Prefs.unlockedLevel;
        if (unlockedWorld == 0)
        {
            levels = unlockedSubWorld switch
            {
                0 => unlockedLevel,
                1 => 14 + unlockedLevel,
                2 => 14 * 2 + unlockedLevel,
                3 => 14 * 2 + 18 + unlockedLevel,
                4 => 14 * 2 + 18 * 2 + unlockedLevel,
                _ => levels
            };
        }
        else
        {
            levels = 82 + 90 * (unlockedWorld - 1);
            levels += unlockedSubWorld switch
            {
                0 => unlockedLevel,
                1 => 18 + unlockedLevel,
                2 => 18 * 2 + unlockedLevel,
                3 => 18 * 3 + unlockedLevel,
                4 => 18 * 4 + unlockedLevel,
                _ => levels
            };
        }
        targets.Add(levels);
        targets.Add(CPlayerPrefs.GetInt("spent_coin"));
        targets.Add(Prefs.extraProgress);
        targets.Add(CPlayerPrefs.GetInt("words_count"));
        targets.Add(CPlayerPrefs.GetInt("words_count"));
        targets.Add(CurrencyController.GetBalance() + CPlayerPrefs.GetInt("spent_coin"));
        targets.Add(CurrencyController.GetBalance() + CPlayerPrefs.GetInt("spent_coin"));

        int length = items.Length;
        for (int i = 0; i < length; i++)
        {
            items[i].slide.value = targets[i];
            items[i].SliderListener(targets[i]);
        }
    }
}