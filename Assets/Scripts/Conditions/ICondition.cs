using System;

public interface ICondition
{
    event Action Completed;
    void Update();
    void Enable();
    void Disable();
}
