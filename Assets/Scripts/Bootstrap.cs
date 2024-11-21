using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private SimpleShooter _simpleShooterPrefab;

    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private GameController _gameController;

    [SerializeField] private WinConditionType _winConditionType;
    [SerializeField] private int _timeToSurvive;
    [SerializeField] private int _enemiesToKill;

    [SerializeField] private LoseConditionType _loseConditionType;
    [SerializeField] private int _maxCountEnemies;


    private void Awake()
    {
        Character character = Instantiate(_characterPrefab, Vector3.zero, Quaternion.identity, null);

        CharacterController characterController = character.GetComponent<CharacterController>();

        SimpleShooter simpleShooter = Instantiate(_simpleShooterPrefab);

        simpleShooter.transform.SetParent(character.transform, false);
        simpleShooter.transform.localPosition = character.ShootPoint.localPosition;

        character.Initialize(
            new InputMoveComponent(character.transform, character.Speed, character.RotationSpeed, characterController),
            simpleShooter,
            new Health(30));

        _cameraManager.Initialize(character.transform);

        _enemySpawner.Initialize();

        ICondition winCondition = GetWinCondition(_winConditionType);
        ICondition loseCondition = GetLoseCondition(_loseConditionType);

        _gameController.Initialize(winCondition, loseCondition, _enemySpawner);
    }

    private ICondition GetWinCondition(WinConditionType winConditionType)
    {
        switch (winConditionType)
        {
            case WinConditionType.SurviveForTime:
                return new SurviveForTimeCondition(_timeToSurvive);

            case WinConditionType.KillEnemies:
                return new KillEnemiesCondition(_enemiesToKill);

            default:
                return null;
        }
    }

    private ICondition GetLoseCondition(LoseConditionType loseConditionType)
    {
        switch (loseConditionType)
        {
            case LoseConditionType.CharacterDied:
                return new CharacterDiedCondition();

            case LoseConditionType.TooManyEnemies:
                return new TooManyEnemiesCondition(_maxCountEnemies);

            default:
                return null;
        }
    }

}
