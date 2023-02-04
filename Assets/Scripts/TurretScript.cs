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
    public Animator animator;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, Vector3.down, range);
        if(hits !=null)
        {
            target = ChooseTarget(hits);
            if (target != null)
            {
                barrel.LookAt(target, Vector3.up);
                Shoot();
            }
        }
        if(target==null)
        {
            animator.Play("Armature|Idle");
        }
    }

    void Shoot()
    {
        if (time < Time.time)
        {
            GameObject temp = Instantiate(projectile, muzzle.position, muzzle.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * projectileSpeed, ForceMode.VelocityChange);
            temp.GetComponent<ProjectileScript>().Setup(damage);
            time = Time.time + delay;
            animator.Play("Armature|Shoot");
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
        if(possibleTargets !=null)
        {
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
            if(target!=null)
            {
                if (target.position.x < 0)
                {
                    Quaternion newRot = Quaternion.Euler(body.rotation.x, 270, body.rotation.z);
                    body.rotation = newRot;
                }
                else
                {
                    Quaternion newRot = Quaternion.Euler(body.rotation.x, 90, body.rotation.z);
                    body.rotation = newRot;
                }
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
