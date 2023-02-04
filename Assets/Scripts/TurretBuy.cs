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
            Destroy(gameObject);
            manager.OnPurchased();
        }
        else { Debug.Log("POOR"); }
    }
}
