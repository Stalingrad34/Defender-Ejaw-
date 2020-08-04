using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/GameData")]

public class GameData : ScriptableObject
{
    public GameObject[] Enemys = null;
    [SerializeField] private int _waves = 0;
    [SerializeField] private float _wavesDuration = 0.0f;
    [SerializeField] private int _health = 0;
    [SerializeField] private int _coins = 0;
    
    public int Waves => _waves;
    public int Health => _health;
    public int Coins => _coins;
    public float WavesDuration => _wavesDuration;
        
    private void OnValidate()
    {
        if (_wavesDuration <= 0) _wavesDuration = 1;
        if (_waves <= 0) _waves = 1;
        if (_health <= 0) _health = 1;
        if (_coins < 0) _coins = 0;
    }

    public void ChangeCoins(int coins)
    {
        _coins += coins;
    }


}
