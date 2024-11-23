using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private SimpleShooter _simpleShooterPrefab;

    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private AliveEnemiesText _aliveEnemiesTextUI;

    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private GameController _gameController;

    [SerializeField] private WinConditionType _winConditionType;
    [SerializeField] private LoseConditionType _loseConditionType;


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

        EnemyList enemiesList = new EnemyList();

        _enemySpawner.Initialize(enemiesList);
        _aliveEnemiesTextUI.Initalize(enemiesList);

        ConditionFactory conditionFactory = new ConditionFactory(_winConditionType, _loseConditionType, enemiesList);

        ICondition winCondition = conditionFactory.CreateWinCondition();
        ICondition loseCondition = conditionFactory.CreateLoseCondition();

        _gameController = new GameController(winCondition, loseCondition, _enemySpawner);

    }

    private void Start()
    {
        _gameController.Start();
    }

    private void Update()
    {
        _gameController.Update();
    }
}
