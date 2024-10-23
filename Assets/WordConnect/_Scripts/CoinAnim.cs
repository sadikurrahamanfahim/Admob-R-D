using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinAnim : MonoBehaviour
{
    public int coinCount = 4;
    public GameObject coin;
    public Transform canvas, target;
    public Canvas thisCanvas;
    
#region Singleton
    // Static reference to the instance of the SingletonExample class
    private static CoinAnim _instance;

    // Public property to access the Singleton instance
    public static CoinAnim Instance
    {
        get
        {
            // If the instance hasn't been set yet, try to find it in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoinAnim>();

                // If it's still not found, create a new GameObject and attach the script to it
                if (_instance == null)
                {
                    GameObject coinAnim = new GameObject("CoinAnim");
                    _instance = coinAnim.AddComponent<CoinAnim>();
                }
            }
            return _instance;
        }
    }

    // Optional: If you want to persist the Singleton across scenes, uncomment the line below
    // private void Awake() => DontDestroyOnLoad(gameObject);

    // Ensure that there can only be one instance of the Singleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Uncomment this line if you want to persist the Singleton across scenes
        }
    }
    #endregion Singleton

    public void StartCoinAnimation(int amount, Vector3 position, bool isPurchase = true)
    {
        if(amount == 0) return;
        target = GameObject.Find("Ruby").transform;
        canvas = GameObject.Find("Canvas").transform;
        thisCanvas.worldCamera = Camera.main;
        for (int i = 0; i < coinCount; i++)
        {
            GameObject tempCoin = Instantiate(coin, canvas);
            Canvas can = tempCoin.AddComponent<Canvas>();
            can.overrideSorting = true;
            can.sortingLayerID = SortingLayer.NameToID("UI2");
            can.sortingOrder = 1;
            tempCoin.transform.localPosition = position + new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0) + new Vector3(50,-65,0);
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
