using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float damage = 10;
    public float delay = 0.1f;
    public float range = 10;
    public float projectileSpeed = 10;
    public float rotSpeed;
    public GameObject projectile;
    public Transform barrel;
    public Transform muzzle;
    Transform target;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, Vector3.down, range);
        target = ChooseTarget(hits);
        barrel.LookAt(target, Vector3.up);
        if (target != null)
            Shoot();
    }

    void Shoot()
    {
        if (time < Time.time)
        {
            GameObject temp = Instantiate(projectile,muzzle.position,muzzle.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * projectileSpeed, ForceMode.VelocityChange);
            temp.GetComponent<ProjectileScript>().Setup(damage);
            time = Time.time + delay;
        }
    }
    Transform ChooseTarget(RaycastHit[] hits)
    {
        Transform target = null;
        List<Transform> possibleTargets = new List<Transform>();
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.CompareTag("Enemy"))
            {
                possibleTargets.Add(hits[i].transform);
            }
        }
        foreach (Transform possibleTarget in possibleTargets)
        {
            if (target == null)
            {
                target = possibleTarget;
            }
            if (Vector3.Distance(transform.position, target.position) > Vector3.Distance(transform.position, possibleTarget.position))
            {
                target = possibleTarget;
            }
        }
        return target;
    }
    public void UpgradeRange()
    {
        range *= 1.05f;
    }
    public void UpgradeDamage()
    {
        damage *= 1.05f;
    }
    public void UpgradeShootSpeed()
    {
        delay *= 0.99f;
    }
}
