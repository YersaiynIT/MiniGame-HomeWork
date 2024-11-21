using UnityEngine;

public class InputMoveComponent : MoveComponent
{
    private CharacterController _characterController;

    public InputMoveComponent(Transform movableTransform, float movableSpeed, float movableRotationSpeed
        , CharacterController characterController)
        : base(movableTransform, movableSpeed, movableRotationSpeed)
    {
        _characterController = characterController;
    }

    public override void Move()
    {
        Vector3 moveDirection = GetInputDirection();

        if (moveDirection.magnitude <= DeadZone)
            return;

        _characterController.Move(moveDirection.normalized * MovableSpeed * Time.deltaTime);
        LookRotationTo(moveDirection.normalized);
    }

    public Vector3 GetInputDirection()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        return inputDirection;
    }
}
