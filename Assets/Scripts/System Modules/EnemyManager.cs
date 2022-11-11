using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameObject RandomEnemy => enemyList.Count == 0 ? null : enemyList[Random.Range(0, enemyList.Count)];
    public int WaveNumber => waveNumber;
    public float TimeBetweenWaves => timeBetweenWaves;
    public Collider2D[] colliders;

    public PolygonCollider2D polygonCollider;
    public int numberRandomPositions = 10;

    public float radius;
    public LayerMask mask;
    [SerializeField] bool spawnEnemy = true;
    [SerializeField] protected GameObject spawnVFX;
    [SerializeField] GameObject waveUI;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] float timeUIWarning = 1f;
    [SerializeField] int minEnemyAmount = 4;
    [SerializeField] int maxEnemyAmount = 10;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] int bossWaveNumber;
    [SerializeField] bool spawnBoss = false;

    public Vector3 center;
    public Vector3 size;

    WaitForSeconds waitTimeBetweenSpawns;
    WaitForSeconds waitTimeBetweenWaves;
    WaitForSeconds waitUIWarning;
    WaitUntil waitUntilNoEnemy;

    int waveNumber = 1;
    int enemyAmount;
    Vector3 pos;

    Vector3 rndPoint3D;
    Vector2 rndPoint2D;
    Vector2 rndPointInside;

    List<GameObject> enemyList;

    protected override void Awake()
    {
        base.Awake();
        enemyList = new List<GameObject>();
        waitTimeBetweenSpawns = new WaitForSeconds(timeBetweenSpawns);
        waitTimeBetweenWaves = new WaitForSeconds(timeBetweenWaves);
        waitUIWarning = new WaitForSeconds(timeUIWarning);
        waitUntilNoEnemy = new WaitUntil(() => enemyList.Count == 0);
    }


    IEnumerator Start()
    {
        if (polygonCollider == null) GetComponent<PolygonCollider2D>();
        // int j = 0;
        // while ( j < numberRandomPositions)
        // {
        //     Vector3 rndPoint3D = RandomPointInBounds(polygonCollider.bounds, 1f);
        //     Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
        //     Vector2 rndPointInside = polygonCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
        //     if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
        //     {
        //         GameObject rndCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //         rndCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //         rndCube.transform.position = rndPoint2D;
        //         j++;
        //     }
        // }
        while(spawnEnemy && GameManager.GameState != GameState.GameOver)
        {
            yield return waitTimeBetweenWaves;
            yield return  StartCoroutine(nameof(RandomlySpawnCoroutine));
        }
    }

    private void Update()
    {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
        rndPoint3D = RandomPointInBounds(polygonCollider.bounds, 1f);
        rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
        rndPointInside = polygonCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
        
    }

    IEnumerator RandomlySpawnCoroutine()
    {
        Vector3 spawnPos = new Vector3(0,0,0);
        bool canSpawnHere = false;
        // int safetyNet = 0;
        if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
        {
            if(waveNumber % bossWaveNumber == 0 && spawnBoss == true)
            {
                waveUI.SetActive(true);
                yield return waitUIWarning;
                waveUI.SetActive(false);
                var boss = Instantiate(bossPrefab, rndPoint2D, Quaternion.identity);
                // var boss = PoolManager.Release(bossPrefab, pos);
                enemyList.Add(boss);
            }
            else
            {
                enemyAmount = Mathf.Clamp(enemyAmount, minEnemyAmount + waveNumber / bossWaveNumber, maxEnemyAmount);

                for(int i = 0; i < enemyAmount; i++)
                {
                    canSpawnHere = PreventOverLap(pos);
                    enemyList.Add(Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], rndPoint2D, Quaternion.identity));
                    // enemyList.Add(PoolManager.Release(enemyPrefab[Random.Range(0, enemyPrefab.Length)], pos));
                    PoolManager.Release(spawnVFX, rndPoint2D);
                    // enemyList.Add(PoolManager.Release(enemyPrefab[enemyPrefab.Length]));

                    yield return waitTimeBetweenSpawns;
                }

            }
            yield return waitUntilNoEnemy;

            waveNumber++;
        }


        // while(!canSpawnHere)
        // {

        //     if(waveNumber % bossWaveNumber == 0 && spawnBoss == true)
        //     {
        //         waveUI.SetActive(true);
        //         yield return waitUIWarning;
        //         waveUI.SetActive(false);
        //         var boss = Instantiate(bossPrefab, pos, Quaternion.identity);
        //         // var boss = PoolManager.Release(bossPrefab, pos);
        //         enemyList.Add(boss);
        //     }
        //     else
        //     {
        //         enemyAmount = Mathf.Clamp(enemyAmount, minEnemyAmount + waveNumber / bossWaveNumber, maxEnemyAmount);

        //         for(int i = 0; i < enemyAmount; i++)
        //         {
        //             canSpawnHere = PreventOverLap(pos);
        //             enemyList.Add(Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], pos, Quaternion.identity));
        //             // enemyList.Add(PoolManager.Release(enemyPrefab[Random.Range(0, enemyPrefab.Length)], pos));
        //             PoolManager.Release(spawnVFX, pos);
        //             // enemyList.Add(PoolManager.Release(enemyPrefab[enemyPrefab.Length]));

        //             yield return waitTimeBetweenSpawns;
        //         }

        //     }
        //     yield return waitUntilNoEnemy;

        //     waveNumber++;
        // }

    }
    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
    
    bool PreventOverLap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius, mask);
        for(int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if(spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if(spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }
    

    public void RemoveFromList(GameObject enemy)
    {  
        enemyList.Remove(enemy);
        Destroy(enemy);
        // enemyList.RemoveAll(enemy => enemy == null);
    }
}
