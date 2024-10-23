using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class ButtonPlay : MyButton {
    public int gotoIndex = 1;
    public bool useScreenFader;
    int world, subWorld, level;

 
    protected override void Start()
    {
        base.Start();
        world = Prefs.unlockedWorld;
        subWorld = Prefs.unlockedSubWorld;
        level = Prefs.unlockedLevel;
        //Debug.Log("word :" + world.ToString());
        //Debug.Log("subWorld :" + subWorld.ToString());

        //Debug.Log("level :" + level.ToString());
    }

    public override async void OnButtonClick()
    {
        base.OnButtonClick();

        // Wait for 2 seconds
        await Task.Delay(1000);

#if UNITY_WEBGL
    CUtils.LoadScene(gotoIndex, useScreenFader);
#else
        CUtils.LoadScene(world == 0 && subWorld == 0 && level == 0 ? 2 : gotoIndex);
#endif
    }
}
