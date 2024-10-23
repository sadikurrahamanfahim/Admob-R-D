using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Theme", menuName = "Theme", order = 1)]
public class ThemeItem : ScriptableObject
{
    public Sprite downBg, buttonBg, hints, hintsBg, leafLeft, leafRight, replay, starButton, topBg;
}
