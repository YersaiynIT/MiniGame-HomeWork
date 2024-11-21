using UnityEngine;

public class SimpleShooter : MonoBehaviour, IShooter
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed;

    public void Shoot(Vector3 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity, null);

        bullet.Launch(direction, _bulletSpeed);
    }
}
