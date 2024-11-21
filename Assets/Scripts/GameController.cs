using UnityEngine;

public class GameController : MonoBehaviour
{
    private ICondition _winCondition;
    private ICondition _loseCondition;

    private EnemySpawner _enemySpawner;

    public void Initialize(ICondition winCondition, ICondition loseCondition, EnemySpawner enemySpawner)
    {
        _winCondition = winCondition;
        _loseCondition = loseCondition;

        _enemySpawner = enemySpawner;
    }

    private void Start()
    {
        _winCondition.Completed += OnWinConditionCompleted;
        _loseCondition.Completed += OnLoseConditionCompleted;
    }

    private void Update()
    {
        _winCondition.CheckCondition();
        _loseCondition.CheckCondition();
    }

    private void EndGame(string message)
    {
        _winCondition.Completed -= OnWinConditionCompleted;
        _loseCondition.Completed -= OnLoseConditionCompleted;

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
