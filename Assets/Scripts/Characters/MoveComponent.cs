using UnityEngine;

public abstract class MoveComponent : IMovable
{
    protected const float DeadZone = 0.05f;

    protected Transform MovableTransform { get; }
    protected float MovableSpeed { get; }
    protected float MovableRotationSpeed { get; }

    public MoveComponent(Transform movableTransform, float movableSpeed, float movableRotationSpeed)
    {
        MovableTransform = movableTransform;
        MovableSpeed = movableSpeed;
        MovableRotationSpeed = movableRotationSpeed;
    }

    public abstract void Move();

    protected void LookRotationTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = MovableRotationSpeed * Time.deltaTime;

        MovableTransform.rotation = Quaternion.RotateTowards(MovableTransform.rotation, lookRotation, step);
    }

}
