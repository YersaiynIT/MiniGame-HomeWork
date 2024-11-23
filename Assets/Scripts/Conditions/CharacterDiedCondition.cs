using System;

public class CharacterDiedCondition : ICondition
{
    public event Action Completed;

    public CharacterDiedCondition() => Enable();

    private void OnCharacterDied() => Completed?.Invoke();

    public void Update() { }

    public void Enable()
    {
        GlobalEventManager.CharacterDied += OnCharacterDied;
    }

    public void Disable()
    {
        GlobalEventManager.CharacterDied -= OnCharacterDied;
    }
}
