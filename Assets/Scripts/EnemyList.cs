using System;
using System.Collections.Generic;

public class EnemyList
{
    public event Action Added;
    public event Action Removed;

    private List<Enemy> _enemies = new();

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        Added?.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Removed?.Invoke();
    }

    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
}
