using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyInstance;

    public float spawnInterval;
    public int enemyLimit;
    private float spawnTimer;
    private int prevEnemyLimit;
    private int currentEnemyCount;

    void Awake()
    {
        currentEnemyCount = 0;
        spawnTimer = spawnInterval;
        prevEnemyLimit = enemyLimit;
    }

    void Update()
    {
        if (enemyLimit != prevEnemyLimit)
        {
            
        }

        if (spawnInterval > 0 && enemyLimit >= 0)
        {
            if (spawnTimer > 0)
                spawnTimer -= Time.deltaTime;
            else
            {
                spawnTimer = spawnInterval;
                Summon();

            }
        }
    }

    public void Summon()
    {
        Instantiate(enemyInstance, transform.position, Quaternion.identity);
    }

    public void EnemyDeathSignal()
    {
        currentEnemyCount--;
    }
}
