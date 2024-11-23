using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionFactory
{
    private WinConditionType _winConditionType;
    private LoseConditionType _loseConditionType;

    private EnemyList _enemies;

    public ConditionFactory(WinConditionType winConditionType, LoseConditionType loseConditionType, EnemyList enemies)
    {
        _winConditionType = winConditionType;
        _loseConditionType = loseConditionType;

        _enemies = enemies;
    }

    private int _timeToSurvive = 20;
    private int _enemiesToKill = 5;
    private int _maxCountEnemies = 5;

    public ICondition CreateWinCondition()
    {
        switch (_winConditionType)
        {
            case WinConditionType.SurviveForTime:
                return new SurviveForTimeCondition(_timeToSurvive);

            case WinConditionType.KillEnemies:
                return new KillEnemiesCondition(_enemiesToKill);

            default:
                return null;
        }
    }

    public ICondition CreateLoseCondition()
    {
        switch (_loseConditionType)
        {
            case LoseConditionType.CharacterDied:
                return new CharacterDiedCondition();

            case LoseConditionType.TooManyEnemies:
                return new TooManyEnemiesCondition(_enemies, _maxCountEnemies);

            default:
                return null;
        }
    }
}
