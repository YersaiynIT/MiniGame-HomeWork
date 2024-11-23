using System;

public class KillEnemiesCondition : ICondition
{
    public event Action Completed;

    private int _enemiesToKill;
    private int _enemiesKilled;

    public KillEnemiesCondition(int enemiesToKill)
    {
        _enemiesToKill = enemiesToKill;

        Enable();
    }

    public void Update()
    {
        if (_enemiesKilled >= _enemiesToKill)
            Completed?.Invoke();
    }

    public void OnEnemyKilled(Enemy enemy) => _enemiesKilled++;

    public void Enable()
    {
        GlobalEventManager.EnemyKilled += OnEnemyKilled;
    }

    public void Disable()
    {
        GlobalEventManager.EnemyKilled -= OnEnemyKilled;
    }
}
