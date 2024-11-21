using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KilledText : MonoBehaviour
{
    [SerializeField] private TMP_Text _killedUI;

    private int _killed;

    private void Awake()
    {
        GlobalEventManager.EnemyKilled += OnEnemyKilled;
    }

    private void OnDestroy()
    {
        GlobalEventManager.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        _killed++;

        _killedUI.text = "Killed: " + _killed.ToString();

    }
}
