using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour {
    public MaskableGraphic itemName, itemNumber, itemNumberBack;
    public Image play, clearImage;
    public Toggle toggleButton;
    public Sprite playUnactive;
    public Text processText, subWorldName, txtNumlevelMax;

    public int world, subWorld;
    public Transform subLevels;

	private void Start()
    {
        clearImage.gameObject.SetActive(false);
        // world = transform.parent.parent.GetSiblingIndex();
        // subWorld = transform.GetSiblingIndex();
        int numLevels = dotMob.Utils.GetNumLevels(world, subWorld);

        int unlockedWorld = Prefs.unlockedWorld;
        int unlockedSubWorld = Prefs.unlockedSubWorld;
        int unlockedLevel = Prefs.unlockedLevel;

        //Debug.Log("unlockedLevel :" + unlockedLevel.ToString());
       // Debug.Log("numLevels :" + numLevels.ToString());

        if (world > unlockedWorld || (world == unlockedWorld && subWorld > unlockedSubWorld))
        {
           
            SetColorAlpha(itemName, 0.5f);
            SetColorAlpha(itemNumber, 0.5f);
            SetColorAlpha(itemNumberBack, 0.5f);
            toggleButton.interactable = false;
            play.sprite = playUnactive;

            processText.text = "0" + "/" + numLevels;
            processText.gameObject.SetActive(false);
        }
        else if (world == unlockedWorld && subWorld == unlockedSubWorld)
        {
            processText.text = unlockedLevel + "/" + numLevels;
            ColorUtility.TryParseHtmlString("#559533b3", out Color newCol);
            txtNumlevelMax.color = newCol;
            processText.gameObject.SetActive(true);

        }
        else
        {
            processText.text = numLevels + "/" + numLevels;
            clearImage.gameObject.SetActive(true);
            ColorUtility.TryParseHtmlString("#865947", out Color newCol);
            txtNumlevelMax.color = newCol;
            processText.gameObject.SetActive(true);

        }

        // toggleButton.onValueChanged.AddListener(OnButtonClick);
    }

    private void SetColorAlpha(MaskableGraphic graphic, float alpha)
    {
        graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, alpha);
    }

    public void OnButtonClick()
    {
        if (subLevels.gameObject.activeSelf)
        {
            subLevels.gameObject.SetActive(false);
            if (transform.GetSiblingIndex()+1 == subLevels.GetSiblingIndex()) return;
        }
        GameState.currentWorld = world;
        GameState.currentSubWorld = subWorld;
        GameState.currentSubWorldName = subWorldName.text;
        // Debug.Log(transform.GetSiblingIndex());
        subLevels.SetAsLastSibling();
        subLevels.SetSiblingIndex(transform.GetSiblingIndex()+1);
        subLevels.gameObject.SetActive(true);
        subLevels.GetComponent<SelectLevelController>().Generate();

        // CUtils.LoadScene(2, true);
        // Sound.instance.PlayButton();
    }
}
