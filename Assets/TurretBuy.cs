using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuy : MonoBehaviour
{
    public Transform turretSpawn;
    public GameObject turretObject;
    // Start is called before the first frame update
    public void OnPurchase()
    {
        Instantiate(turretObject, turretSpawn);
        Destroy(gameObject);
    }
}
