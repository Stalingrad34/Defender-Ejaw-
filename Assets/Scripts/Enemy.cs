using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager GameManager = null;
    [SerializeField] private EnemyData _enemyData = null;
    private int damage = 0;
    private int health = 0;
    private int coins = 0;

    private void Start()
    {
        damage = _enemyData.Damage;
        health = _enemyData.Health;
        coins = _enemyData.Coins;

        var ter = new Terrain();
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.ChangeCoins(coins);
            ToDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            GameManager.TakeDamage(damage);
        }
    }

    private void ToDie()
    {
        Messenger.Broadcast(GameEvent.ENEMY_KILL);
        Destroy(gameObject);
    }
}
