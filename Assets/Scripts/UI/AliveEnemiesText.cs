using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AliveEnemiesText : MonoBehaviour
{
    [SerializeField] private TMP_Text _aliveEnemiesUI;

    private int _aliveEnemies;

    private void Awake()
    {
        GlobalEventManager.EnemyKilled += OnEnemyKilled;
    }

    private void OnDestroy()
    {
        GlobalEventManager.EnemyKilled -= OnEnemyKilled;
    }

    private void Update()
    {
        _aliveEnemies = EnemyArchive.GetEnemies().Count;

        _aliveEnemiesUI.text = "AliveEnemies: " + _aliveEnemies.ToString();
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        

    }
}