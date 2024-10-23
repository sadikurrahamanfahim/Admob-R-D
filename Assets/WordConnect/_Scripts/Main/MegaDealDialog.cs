using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Purchasing;

public class MegaDealDialog : Dialog {
    public override void Close ()
	{
		base.Close ();
		
	}
	
	public TextMeshProUGUI[] numRubyTexts, priceTexts;
    public Transform coinPosition;

	protected override void Start()
	{
		base.Start();
#if IAP && UNITY_PURCHASING
        Purchaser.instance.onItemPurchased += OnItemPurchased;
#endif
	}

    public void MegaDealOpen()
    {
        PlayerPrefs.SetInt("isMegaDealOpen", MegaDealSystem.isMegaDealOpen = 1);
    }

    public void OnBuyProduct(int index)
	{
#if IAP && UNITY_PURCHASING
        Sound.instance.PlayButton();
        Purchaser.instance.BuyProduct(index);
#else
		Debug.LogError("Please enable, import and install Unity IAP to use this function");
#endif
	}

#if IAP && UNITY_PURCHASING
    private void OnItemPurchased(IAPItem item, int index)
    {
        // A consumable product has been purchased by this user.
        if (item.productType == ProductType.Consumable)
        {
            CoinAnim.Instance.StartCoinAnimation(item.value, coinPosition.localPosition);
            Invoke(nameof(Close), 0.2f);
        }
        // Or ... a non-consumable product has been purchased by this user.
        else if (item.productType == ProductType.NonConsumable)
        {
            // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
        }
        // Or ... a subscription product has been purchased by this user.
        else if (item.productType == ProductType.Subscription)
        {
            // TODO: The subscription item has been successfully purchased, grant this to the player.
        }
    }
#endif

#if IAP && UNITY_PURCHASING
    private void OnDestroy()
    {
        Purchaser.instance.onItemPurchased -= OnItemPurchased;
    }
#endif
	
}
