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

        Enable();
    }

    private void OnCharacterDied() => _isCharacterDied = true;

    public void Update()
    {
        if (_isCharacterDied)
            return;

        _time += Time.deltaTime;

        if (_time >= _timeToSurvive)
            if (_isCharacterDied == false)
                Completed?.Invoke();
    }

    public void Enable()
    {
        GlobalEventManager.CharacterDied += OnCharacterDied;
    }

    public void Disable()
    {
        GlobalEventManager.CharacterDied -= OnCharacterDied;
    }
}
