using UnityEngine;

public class RandomMoveComponent : MoveComponent
{
    private Vector3 _currentDirection;

    private float _timeToSwitchDirection;
    private float _time;

    public RandomMoveComponent(Transform movableTransform, float movableSpeed, float movableRotationSpeed
        , float timeToSwitchDirection) : base(movableTransform, movableSpeed, movableRotationSpeed)
    {
        _timeToSwitchDirection = timeToSwitchDirection;

        _currentDirection = GetRandomDirection();
    }

    public override void Move()
    {
        MovableTransform.Translate(_currentDirection.normalized * MovableSpeed * Time.deltaTime, Space.World);
        LookRotationTo(_currentDirection.normalized);

        _time += Time.deltaTime;

        if (_time >= _timeToSwitchDirection)
        {
            _currentDirection = GetRandomDirection();
            _time = 0;
        }
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 randomMoveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        return randomMoveDirection;
    }
}
