using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float waveNumber = 0;
    public float enemyCount = 2;
    public float currentEnemyCount = 0;
    public List<Transform> spawns;
    public GameObject enemy;
    public float spawnDelay = 1;
    public GameObject button;
    float buttonDelay = 1f;
    float buttonAppears = 0;
    Vector3 enemyStats = new Vector3(100, 10, 2);

    private bool combat = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (combat && currentEnemyCount == 0 && buttonAppears < Time.time)
        {
            combat = false;
            button.SetActive(true);
            MinePower.ResetMinePower();
        }
    }
    public void OnStartNewWave()
    {
        waveNumber++;
        enemyCount += waveNumber;
        spawnDelay *= 0.95f;
        StartCoroutine(Spawn());
        combat = true;
        button.SetActive(false);
        enemyStats *= 1.05f;
        FindAnyObjectByType<UIManager>().UpdateWave(waveNumber);
        buttonAppears = Time.time + buttonDelay;
    }
    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
    }
    IEnumerator Spawn()
    {
        for(int i=0;i<enemyCount;i++)
        {
            int spawn = Random.Range(0, spawns.Count);
            currentEnemyCount++;
            GameObject temp = Instantiate(enemy, spawns[spawn]);
            temp.GetComponent<EnemyScript>().Setup(enemyStats.x,enemyStats.y,enemyStats.z);
            yield return new WaitForSeconds(spawnDelay);

        }
        yield return null;
    }
}
