using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AliveEnemiesText : MonoBehaviour
{
    [SerializeField] private TMP_Text _aliveEnemiesUI;

    private EnemyList _enemies;
    private int _aliveEnemies;

    public void Initalize(EnemyList enemies)
    {
        _enemies = enemies;
    }

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
        _aliveEnemies = _enemies.GetEnemies().Count;

        _aliveEnemiesUI.text = "AliveEnemies: " + _aliveEnemies.ToString();
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        

    }
}