using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopCoinAnim : MonoBehaviour
{
    public int coinCount = 4;
    public GameObject coin;
    public Transform canvas, target;

    public void StartCoinAnimation(int amount, Transform transformCoin, bool isPurchase = true)
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject tempCoin = Instantiate(coin, transformCoin);
            // Canvas can = tempCoin.AddComponent<Canvas>();
            // can.overrideSorting = true;
            // can.sortingLayerID = SortingLayer.NameToID("UI2");
            // can.sortingOrder = 1;
            tempCoin.transform.localPosition = transformCoin.position + new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0) + new Vector3(-60,30,0);
            tempCoin.transform.DOScale(1f, 0.4f).OnComplete(() =>
            {
                tempCoin.transform.DOMove(target.position, 0.4f).SetDelay(Random.Range(0f, 0.2f)).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Destroy(tempCoin);
                    target.DOScale(new Vector3(1.4f,1.4f,1.4f), .1f).OnComplete(() =>
                    {
                        target.DOScale(new Vector3(1f,1f,1f), .1f);
                    });
                });
            });
        }
        StartCoroutine(AddCoin(amount, isPurchase));
    }

    private IEnumerator AddCoin(int amount, bool isPurchase)
    {
        yield return new WaitForSeconds(1.4f);
        CurrencyController.CreditBalance(amount);
        if(isPurchase)
        {
            Toast.instance.ShowMessage("Your purchase is successful");
            CUtils.SetBuyItem();
        }
    }
}
