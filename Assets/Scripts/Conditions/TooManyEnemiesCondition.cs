using System;
using System.Collections.Generic;

public class TooManyEnemiesCondition : ICondition
{
    public event Action Completed;

    private List<Enemy> _aliveEnemies;
    private int _countAliveEnemies;

    private int _maxCountEnemies;

    public TooManyEnemiesCondition(EnemyList enemies, int maxCountEnemies)
    {
        _aliveEnemies = enemies.GetEnemies();
        _maxCountEnemies = maxCountEnemies;
    }

    public void Update()
    {
        _countAliveEnemies = _aliveEnemies.Count;

        if (_countAliveEnemies >= _maxCountEnemies)
            Completed?.Invoke();
    }

    public void Enable()
    {
        
    }

    public void Disable()
    {
        
    }
}
