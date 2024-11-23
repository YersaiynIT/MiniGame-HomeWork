using UnityEngine;

public class GameController
{
    private ICondition _winCondition;
    private ICondition _loseCondition;

    private EnemySpawner _enemySpawner;

    public GameController(ICondition winCondition, ICondition loseCondition, EnemySpawner enemySpawner)
    {
        _winCondition = winCondition;
        _loseCondition = loseCondition;

        _enemySpawner = enemySpawner;
    }

    public void Start()
    {
        _winCondition.Completed += OnWinConditionCompleted;
        _loseCondition.Completed += OnLoseConditionCompleted;
    }

    public void Update()
    {
        _winCondition.Update();
        _loseCondition.Update();
    }

    private void EndGame(string message)
    {
        _winCondition.Completed -= OnWinConditionCompleted;
        _loseCondition.Completed -= OnLoseConditionCompleted;

        _winCondition.Disable();
        _loseCondition.Disable();

        _enemySpawner.Stop();
        _enemySpawner.StopAllEnemies();

        Debug.Log(message);
    }

    private void OnWinConditionCompleted()
    {
        EndGame("Вы победили!! :)");
    }

    private void OnLoseConditionCompleted()
    {
        EndGame("Вы проиграли!! :(");
    }
}
