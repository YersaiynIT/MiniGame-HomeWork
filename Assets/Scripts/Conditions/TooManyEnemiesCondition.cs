using System;
using System.Collections.Generic;

public class TooManyEnemiesCondition : ICondition
{
    public event Action Completed;

    private List<Enemy> _aliveEnemies = new();
    private int _countAliveEnemies;

    private int _maxCountEnemies;

    public TooManyEnemiesCondition(int maxCountEnemies)
    {
        _maxCountEnemies = maxCountEnemies;
    }

    public void CheckCondition()
    {
        _aliveEnemies = EnemyArchive.GetEnemies();

        _countAliveEnemies = _aliveEnemies.Count;

        if (_countAliveEnemies >= _maxCountEnemies)
            Completed?.Invoke();
    }
}
