using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;

    private float _lifeTime = 3f;
    private float _time;

    public void Launch(Vector3 direction, float speed)
    {
        _rigidbody.AddForce(direction * speed, ForceMode.Impulse);
    }

    private void Update() => DestroyAfterLifetime();

    private void DestroyAfterLifetime()
    {
        _time += Time.deltaTime;

        if (_time >= _lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable != null)
            damagable.ApplyDamage(_damage);

        Destroy(gameObject);
    }
}
