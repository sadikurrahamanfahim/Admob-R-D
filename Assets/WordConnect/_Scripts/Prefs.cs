using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{

    // Unlock world_6 and keep other worlds/subworlds locked
    public static int unlockedWorld
    {
        get
        {
            if (GameState.unlockedWorld == -1)
            {
                int value = CPlayerPrefs.GetInt("unlocked_world");

                // If world_6 is not unlocked, unlock only world_6 (world index 6)
                if (value < 6)  // Assuming 6 represents world_6
                {
                    value = 6;  // Set world_6 as unlocked
                    CPlayerPrefs.SetInt("unlocked_world", value);  // Save the change
                }

                GameState.unlockedWorld = value;
            }
            return GameState.unlockedWorld;
        }
        set
        {
            CPlayerPrefs.SetInt("unlocked_world", value);
            GameState.unlockedWorld = value;
        }
    }

    public static int unlockedSubWorld
    {
        get
        {
            if (GameState.unlockedSubWord == -1)
            {
                int value = CPlayerPrefs.GetInt("unlocked_sub_world");

                // If world_6 is unlocked, unlock only its first subworld (0)
                if (GameState.unlockedWorld == 6 && value < 0)
                {
                    value = 0;  // Unlock the first subworld of world_6
                    CPlayerPrefs.SetInt("unlocked_sub_world", value);  // Save the change
                }
                else if (GameState.unlockedWorld < 6)
                {
                    // Keep all other worlds/subworlds locked
                    value = -1;
                }

                GameState.unlockedSubWord = value;
            }
            return GameState.unlockedSubWord;
        }
        set
        {
            CPlayerPrefs.SetInt("unlocked_sub_world", value);
            GameState.unlockedSubWord = value;
        }
    }

    public static int unlockedLevel
    {
        get
        {
            if (GameState.unlockedLevel == -1)
            {
                int value = CPlayerPrefs.GetInt("unlocked_level");

                // Unlock the first level of the first subworld of world_6
                if (GameState.unlockedWorld == 6 && GameState.unlockedSubWord == 0 && value < 1)
                {
                    value = 1;  // Unlock the first level
                    CPlayerPrefs.SetInt("unlocked_level", value);  // Save the change
                }
                else if (GameState.unlockedWorld < 6)
                {
                    // Keep other worlds' levels locked
                    value = -1;
                }

                GameState.unlockedLevel = value;
            }
            return GameState.unlockedLevel;
        }
        set
        {
            CPlayerPrefs.SetInt("unlocked_level", value);
            GameState.unlockedLevel = value;
        }
    }

    public static List<int> GetPanWordIndexes(int world, int subWorld, int level)
    {
        string data = PlayerPrefs.GetString("pan_word_indexes_v2_" + world + "_" + subWorld + "_" + level);
        return CUtils.BuildListFromString<int>(data);
    }

    public static void SetPanWordIndexes(int world, int subWorld, int level, int[] indexes)
    {
        string data = CUtils.BuildStringFromCollection(indexes);
        PlayerPrefs.SetString("pan_word_indexes_v2_" + world + "_" + subWorld + "_" + level, data);
    }

    public static bool IsLastLevel()
    {
        return GameState.currentWorld == unlockedWorld &&
                GameState.currentSubWorld == unlockedSubWorld &&
                GameState.currentLevel == unlockedLevel;
    }

    public static void SetExtraWords(int world, int subWorld, int level, string[] extraWords)
    {
        CryptoPlayerPrefsX.SetStringArray("extra_words_" + world + "_" + subWorld + "_" + level, extraWords);
    }

    public static string[] GetExtraWords(int world, int subWorld, int level)
    {
        return CryptoPlayerPrefsX.GetStringArray("extra_words_" + world + "_" + subWorld + "_" + level);
    }

    public static int extraProgress
    {
        get { return CPlayerPrefs.GetInt("extra_progress", 0); }
        set { CPlayerPrefs.SetInt("extra_progress", value); }
    }

    public static int extraTarget
    {
        get { return CPlayerPrefs.GetInt("extra_target", 5); }
        set { CPlayerPrefs.SetInt("extra_target", value); }
    }

    public static int totalExtraAdded
    {
        get { return CPlayerPrefs.GetInt("total_extra_added", 0); }
        set { CPlayerPrefs.SetInt("total_extra_added", value); }
    }

    public static string[] levelProgress
    {
        get { return CryptoPlayerPrefsX.GetStringArray("level_progress"); }
        set { CryptoPlayerPrefsX.SetStringArray("level_progress", value); }
    }

    public static bool isNoti1Enabled
    {
        get { return PlayerPrefs.GetInt("is_noti_1_enabled") == 1; }
        set { PlayerPrefs.SetInt("is_noti_1_enabled", value ? 1 : 0); }
    }

    public static bool isNoti2Enabled
    {
        get { return PlayerPrefs.GetInt("is_noti_2_enabled") == 1; }
        set { PlayerPrefs.SetInt("is_noti_2_enabled", value ? 1 : 0); }
    }

    public static int noti3Ruby
    {
        get { return PlayerPrefs.GetInt("noti_3_ruby"); }
        set { PlayerPrefs.SetInt("noti_3_ruby", value); }
    }

    public static int noti4Ruby
    {
        get { return PlayerPrefs.GetInt("noti_4_ruby"); }
        set { PlayerPrefs.SetInt("noti_4_ruby", value); }
    }

    public static int noti5Ruby
    {
        get { return PlayerPrefs.GetInt("noti_5_ruby"); }
        set { PlayerPrefs.SetInt("noti_5_ruby", value); }
    }

    public static int noti6Ruby
    {
        get { return PlayerPrefs.GetInt("noti_6_ruby"); }
        set { PlayerPrefs.SetInt("noti_6_ruby", value); }
    }

    public static int noti7Ruby
    {
        get { return PlayerPrefs.GetInt("noti_7_ruby"); }
        set { PlayerPrefs.SetInt("noti_7_ruby", value); }
    }

    public static void AddToNumHint(int world, int subWorld, int level)
    {
        int numHint = GetNumHint(world, subWorld, level);
        PlayerPrefs.SetInt("numhint_used_" + world + "_" + subWorld + "_" + level, numHint + 1);
    }

    public static int GetNumHint(int world, int subWorld, int level)
    {
        return PlayerPrefs.GetInt("numhint_used_" + world + "_" + subWorld + "_" + level);
    }
}
