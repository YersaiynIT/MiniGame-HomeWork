using UnityEngine;

public class Enemy : MonoBehaviour, IUnit, IDamagable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _timeToSwitchDirection;

    private IMovable _movable;
    private Health _health;

    private bool _isStopped;

    public void Initialize(IMovable movable, Health health)
    {
        _movable = movable;

        _health = health;
        _health.Current.Changed += OnHealthChanged;
    }

    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;
    public float Damage => _damage;
    public float TimeToSwitchDirection => _timeToSwitchDirection;

    private void Update()
    {
        if (_isStopped)
            return;

        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            character.ApplyDamage(_damage);
    }

    private void OnDestroy()
    {
        _health.Current.Changed -= OnHealthChanged;
    }

    public void Move() => _movable.Move();

    public void ApplyDamage(int damage) => _health.Reduce(damage);

    private void OnHealthChanged(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            GlobalEventManager.SendEnemyKilled(this);
            Destroy(gameObject);
        }
    }

    public void Stop() => _isStopped = true;
}
