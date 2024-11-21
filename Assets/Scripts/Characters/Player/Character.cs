using UnityEngine;

public class Character : MonoBehaviour, IUnitWarrior, IDamagable
{
    private const int LeftMouseButtonKey = 0;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _shootPoint;

    private IMovable _movable;
    private IShooter _shooter;

    private Health _health;

    public void Initialize(IMovable movable, IShooter shooter, Health health)
    {
        _movable = movable;
        _shooter = shooter;
        _health = health;

        _health.Current.Changed += OnHealthChanged;
    }

    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;
    public Transform ShootPoint => _shootPoint;

    private void Update()
    {
        ProcessLeftMouseButton();

        Move();
    }

    private void OnDestroy() => _health.Current.Changed -= OnHealthChanged;

    private void ProcessLeftMouseButton()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonKey))
            Attack();
    }

    public void Move() => _movable.Move();

    public void Attack() => _shooter.Shoot(transform.forward);

    public void ApplyDamage(int damage) => _health.Reduce(damage);

    private void OnHealthChanged(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            GlobalEventManager.SendCharacterDied();
            Destroy(gameObject);
        }
    }
}
