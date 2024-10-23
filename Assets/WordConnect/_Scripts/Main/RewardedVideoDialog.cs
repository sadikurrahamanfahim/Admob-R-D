using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedVideoDialog : Dialog {
    public Text amountText;
    public Text messageText;

	public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
        messageText.text = string.Format(messageText.text, amount);
    }

    public void Claim()
    {
        Close();
        CoinAnim.Instance.StartCoinAnimation(int.Parse(amountText.text), amountText.transform.localPosition, false);
        Sound.instance.PlayButton();
    }

    

	public override void Close ()
	{
		base.Close ();
		
	}
}
