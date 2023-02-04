using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class Currency : MonoBehaviour
{

    [SerializeField] private int startingCurrency;
    
    private static int currencyOwned;

    private void Start()
    {
        currencyOwned = startingCurrency;
    }

    public static void SetCurrency(int amount)
    {
        currencyOwned = amount;
    }

    public static void AddCurrency(int amount)
    {
        currencyOwned += amount;
    }

    public static void RemoveCurrency(int amount)
    {
        currencyOwned -= amount;
    }

    public static int GetCurrency()
    {
        return currencyOwned;
    }
}
