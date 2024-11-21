using System;

public class CharacterDiedCondition : ICondition
{
    public event Action Completed;

    public CharacterDiedCondition()
    {
        GlobalEventManager.CharacterDied += OnCharacterDied;
    }

    private void OnCharacterDied()
    {
        Completed?.Invoke();
        GlobalEventManager.CharacterDied -= OnCharacterDied;
    }

    public void CheckCondition()
    {
        
    }
}
