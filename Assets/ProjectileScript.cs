using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    float damage;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup(float dmg)
    {
        damage = dmg;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyScript>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
