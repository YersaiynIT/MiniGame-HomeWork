using System;

public class KillEnemiesCondition : ICondition
{
    public event Action Completed;

    private int _enemiesToKill;
    private int _enemiesKilled;

    public KillEnemiesCondition(int enemiesToKill)
    {
        _enemiesToKill = enemiesToKill;
        GlobalEventManager.EnemyKilled += OnEnemyKilled;
    }

    public void CheckCondition()
    {
        if (_enemiesKilled >= _enemiesToKill)
        {
            GlobalEventManager.EnemyKilled -= OnEnemyKilled;
            Completed?.Invoke();
        }
    }

    public void OnEnemyKilled(Enemy enemy)
    {
        _enemiesKilled++;
    }




}
