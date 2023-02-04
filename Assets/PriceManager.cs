using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public int TurretPrice = 10;
    static float scaling = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseTurretCost()
    {
        TurretPrice = (int)(scaling * TurretPrice);
    }
    public bool CheckIfAffordableTurret()
    {
        if (Currency.currencyOwned > TurretPrice) { return true; }
        else { return false; }
    }
    public void OnPurchased() 
    {
        Currency.RemoveCurrency(TurretPrice);
    }
}
