using System.Collections.Generic;

public class EnemyArchive
{
    private static List<Enemy> _enemies = new();

    public static void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public static void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public static List<Enemy> GetEnemies()
    {
        return _enemies;
    }
}
