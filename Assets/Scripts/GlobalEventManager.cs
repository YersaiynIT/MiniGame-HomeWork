using System;

public class GlobalEventManager
{
    public static event Action<Enemy> EnemyKilled;
    public static event Action CharacterDied;

    public static void SendEnemyKilled(Enemy enemy)
    {
        EnemyKilled?.Invoke(enemy);
    }

    public static void SendCharacterDied()
    {
        CharacterDied?.Invoke();
    }
}
