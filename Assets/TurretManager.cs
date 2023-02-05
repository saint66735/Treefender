using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    List<TurretScript> turrets = new List<TurretScript>();
    public void AddTurret(TurretScript turret)
    {
        turrets.Add(turret);
    }
    public void UpgradeRange()
    {
        foreach(TurretScript turret in turrets)
        {
            turret.UpgradeRange();
        }
    }
    public void UpgradeDamage()
    {
        foreach (TurretScript turret in turrets)
        {
            turret.UpgradeDamage();
        }
    }
    public void UpgradeRoF()
    {
        foreach (TurretScript turret in turrets)
        {
            turret.UpgradeShootSpeed();
        }
    }
}
