using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : EnemyPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Transform> _targetPoints;

    [SerializeField] private EnemyMoverType1 _enemy1Prefab;
    [SerializeField] private EnemyMoverType2 _enemy2Prefab;
    [SerializeField] private EnemyMoverType3 _enemy3Prefab;

    [SerializeField] private float _timeBetweenSpawn = 2f;
    [SerializeField] private float _deactivateTime = 10f;

    private void Start()
    {
        Create(_enemy1Prefab, _enemy2Prefab, _enemy3Prefab);
        StartCoroutine(SpawnEnemiesRepeatedly());
    }
    private void Update()
    {
        if (TryGetObject(out EnemyMoverType1 enemy1, out EnemyMoverType2 enemy2, out EnemyMoverType3 enemy3))
            StartCoroutine(UpdateDeactivateTimer(enemy1, enemy2, enemy3));
    }

    private IEnumerator UpdateDeactivateTimer(EnemyMoverType1 enemy1, EnemyMoverType2 enemy2, EnemyMoverType3 enemy3)
    {
        yield return new WaitForSeconds(_deactivateTime);
        enemy1.gameObject.SetActive(false);
        enemy2.gameObject.SetActive(false);
        enemy3.gameObject.SetActive(false);
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            Transform spawnPoint = _spawnPoints[spawnPointIndex];

            if (TryGetObject(out EnemyMoverType1 enemy1, out EnemyMoverType2 enemy2, out EnemyMoverType3 enemy3))
            {
                SetEnemy(enemy1, enemy2, enemy3, spawnPoint);
            }
        }
    }

    private void SetEnemy(EnemyMoverType1 enemy1, EnemyMoverType2 enemy2, EnemyMoverType3 enemy3, Transform spawnPoint)
    {
        if (spawnPoint == _spawnPoints[0])
        {
            enemy1.transform.position = spawnPoint.position;
            enemy1.gameObject.SetActive(true);

            if (enemy1.TryGetComponent(out EnemyMoverType1 enemyMover1))
            {
                enemyMover1.SetRandomDirection(_targetPoints[0].position);
            }
        }
        else if (spawnPoint == _spawnPoints[1])
        {
            enemy2.transform.position = spawnPoint.position;
            enemy2.gameObject.SetActive(true);

            if (enemy2.TryGetComponent(out EnemyMoverType2 enemyMover2))
            {
                enemyMover2.SetRandomDirection(_targetPoints[1].position);
            }
        }
        else if (spawnPoint == _spawnPoints[2])
        {
            enemy3.transform.position = spawnPoint.position;
            enemy3.gameObject.SetActive(true);

            if (enemy3.TryGetComponent(out EnemyMoverType3 enemyMover3))
            {
                enemyMover3.SetRandomDirection(_targetPoints[2].position);
            }
        }
    }
}