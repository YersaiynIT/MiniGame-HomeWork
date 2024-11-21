using System;

public interface ICondition
{
    event Action Completed;
    void CheckCondition();
}
