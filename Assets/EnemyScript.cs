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
    // Start is called before the first frame update
    void Start()
    {
        waves = FindObjectOfType<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            waves.DecreaseEnemyCount();
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
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
