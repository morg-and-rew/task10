using System.Collections;
using UnityEngine;

public class SpawnerEnemy : EnemyPool
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Transform _targetPoints;

    [SerializeField] private EnemyMover _enemyPrefabs;

    [SerializeField] private float _timeBetweenSpawn = 2f;
    [SerializeField] private float _deactivateTime = 10f;

    private void Start()
    {
        Create(_enemyPrefabs);
        
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    private void Update()
    {
        if (TryGetObject(out EnemyMover enemy))
            StartCoroutine(UpdateDeactivateTimer(enemy));
    }

    private IEnumerator UpdateDeactivateTimer(EnemyMover enemy)
    {
        yield return new WaitForSeconds(_deactivateTime);
        enemy.gameObject.SetActive(false);
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            EnemyMover enemyPrefab = _enemyPrefabs;

            if (TryGetObject(out EnemyMover enemy))
            {
                Transform spawnPoint = _spawnPoints;
                SetEnemy(enemy, spawnPoint, enemyPrefab);
            }
        }
    }

    private void SetEnemy(EnemyMover enemy, Transform spawnPoint, EnemyMover enemyPrefab)
    {
        enemy.transform.position = spawnPoint.position;
        enemy.gameObject.SetActive(true);

        enemy.SetRandomDirection(_targetPoints.position);
    }
}