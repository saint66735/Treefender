using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI waveCount;
    public TextMeshProUGUI newTurretCost;
    public TextMeshProUGUI digsRemaining;
    public TextMeshProUGUI hpText;
    public WaveManager wavesM;
    public PriceManager priceM;
    public PlayerScript player;
    public TurretManager turretM;
    // Start is called before the first frame update
    void Start()
    {
        waveCount.text = "Get ready";
        coins.text = "" + Currency.GetCurrency();
        newTurretCost.text = "New turret costs: " + priceM.TurretPrice;
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "" + Currency.GetCurrency();
        newTurretCost.text = "New turret costs: " + priceM.TurretPrice;
        digsRemaining.text = "Digs remaining: " + MinePower.currentMinePower;
        hpText.text = "" + player.health;
    }
    public void UpdateWave(float wave)
    {
        waveCount.text = "Wave: " + wave;
    }

    public void OnTurretRangeUpgradePurchase()
    {
        if (priceM.CheckIfAffordableUpgrade())
        {
            turretM.UpgradeRange();
            priceM.OnPurchasedUpgrade();
            priceM.IncreaseUpgradeCost();
        }
        else
        {
            Debug.Log("Broke");
        }

    }
    public void OnTurretDamageUpgradePurchase()
    {
        if (priceM.CheckIfAffordableUpgrade())
        {
            turretM.UpgradeDamage();
            priceM.OnPurchasedUpgrade();
            priceM.IncreaseUpgradeCost();
        }
        else
        {
            Debug.Log("Broke");
        }

    }
    public void OnTurretRoFUpgradePurchase()
    {
        if (priceM.CheckIfAffordableUpgrade())
        {
            turretM.UpgradeRoF();
            priceM.OnPurchasedUpgrade();
            priceM.IncreaseUpgradeCost();
        }
        else
        {
            Debug.Log("Broke");
        }

    }
    public void OnDigUpgradePurchase()
    {
        if (priceM.CheckIfAffordableUpgrade())
        {

        }
        else
        {
            Debug.Log("Broke");
        }
    }
}
