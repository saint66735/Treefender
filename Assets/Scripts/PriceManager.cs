using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public int TurretPrice = 10;
    public int upgradePrice = 10;
    float scaling = 1.5f;
    // Start is called before the first frame update
    
    public void IncreaseTurretCost()
    {
        TurretPrice = (int)(scaling * TurretPrice);
        //Debug.Log(TurretPrice);
    }
    public void IncreaseUpgradeCost()
    {
        upgradePrice = (int)(scaling * upgradePrice);
    }
    public bool CheckIfAffordableTurret()
    {
        if (Currency.GetCurrency() >= TurretPrice) { return true; }
        else { return false; }
    }
    public bool CheckIfAffordableUpgrade()
    {
        if (Currency.GetCurrency() >= upgradePrice) { return true; }
        else { return false; }
    }
    public void OnPurchasedTurret() 
    {
        Currency.RemoveCurrency(TurretPrice);
    }
    public void OnPurchasedUpgrade()
    {
        Currency.RemoveCurrency(upgradePrice);
    }
}
