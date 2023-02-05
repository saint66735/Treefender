using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuy : MonoBehaviour
{
    public Transform turretSpawn;
    public GameObject turretObject;
    PriceManager manager;
    private void Start()
    {
        manager = FindObjectOfType<PriceManager>();
    }

    // Start is called before the first frame update
    public void OnPurchase()
    {
        if(manager.CheckIfAffordableTurret())
        {
            Instantiate(turretObject, turretSpawn);
            //Debug.Log(manager.TurretPrice);
            manager.OnPurchasedTurret();
            manager.IncreaseTurretCost();
            Destroy(gameObject);
        }
        else { Debug.Log("POOR"); }
    }
}
