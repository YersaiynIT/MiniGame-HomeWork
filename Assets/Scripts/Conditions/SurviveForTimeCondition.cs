using System;
using UnityEngine;

public class SurviveForTimeCondition : ICondition
{
    public event Action Completed;

    private float _timeToSurvive;
    private float _time;

    private bool _isCharacterDied;

    public SurviveForTimeCondition(float timeToSurvive)
    {
        _timeToSurvive = timeToSurvive;

        GlobalEventManager.CharacterDied += OnCharacterDied;
    }

    private void OnCharacterDied()
    {
        _isCharacterDied = true;
        GlobalEventManager.CharacterDied -= OnCharacterDied;
    }

    public void CheckCondition()
    {
        if (_isCharacterDied)
            return;

        _time += Time.deltaTime;

        if (_time >= _timeToSurvive)
            if (_isCharacterDied == false)
                Completed?.Invoke();
    }


}
