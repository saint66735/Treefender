using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 100;
    public float damage = 10;
    public float speed = 2;
    bool type = false; // false == ground
    WaveManager waves;
    public GameObject deathEffect;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        waves = FindObjectOfType<WaveManager>();
        if (transform.position.x > 0)
        {
            Quaternion newRot = Quaternion.Euler(new Vector3(body.rotation.x, -90, body.rotation.z));
            body.rotation = newRot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        if (!type)
        {
            if (transform.position.x < 0)
            {
                Vector3 newPos = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
            else
            {
                Vector3 newPos = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        else
        {

        }
    }
    public void Setup(float hp, float dmg, float sped)
    {
        health = hp;
        damage = dmg;
        speed = sped;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerScript>().TakeDamage(damage);
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    void Die()
    {
        waves.DecreaseEnemyCount();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
