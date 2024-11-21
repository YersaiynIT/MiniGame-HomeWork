using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _timeBetweenSpawns;

    private Coroutine _spawnCoroutine;

    private bool _isStopped;

    public void Initialize()
    {
        GlobalEventManager.EnemyKilled += OnEnemyKilled;
    }

    private void Update()
    {
        if (_isStopped)
            return;

        if (_spawnCoroutine == null)
            _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void OnDestroy()
    {
        GlobalEventManager.EnemyKilled -= OnEnemyKilled;
    }
    private void OnEnemyKilled(Enemy killedEnemy)
    {
        EnemyArchive.RemoveEnemy(killedEnemy);
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_timeBetweenSpawns);

        Vector3 spawnPoint = GetRandomSpawnPoint();

        if (_isStopped)
            yield break;

        CreateEnemy(spawnPoint);

        _spawnCoroutine = null;
    }

    private void CreateEnemy(Vector3 spawnPoint)
    {
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity, null);

        enemy.Initialize(
            new RandomMoveComponent(enemy.transform, enemy.Speed, enemy.RotationSpeed, enemy.TimeToSwitchDirection),
            new Health(30));

        EnemyArchive.AddEnemy(enemy);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        return spawnPoint.position;
    }

    public void Stop() => _isStopped = true;

    public void StopAllEnemies()
    {
        List<Enemy> enemies = EnemyArchive.GetEnemies();
        enemies.ForEach(enemy => enemy.Stop());
    }
    
}
