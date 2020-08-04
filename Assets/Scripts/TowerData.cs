using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tower")]

public class TowerData : ScriptableObject
{
    public GameObject prefabTower = null;
    public Bullet prefabBullet = null;
    public GameData _gameData = null;
    public TowerType _towerType = 0;

    [SerializeField] private int _buildPrice = 0;
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _range = 0.0f;
    [SerializeField] private float _shootInterval = 0.0f;    
    public int BuildPrice => _buildPrice;
    public int Damage => _damage;
    public float Range => _range;
    public float ShootInterval => _shootInterval;

    public enum TowerType
    {
        ArcherTower,
        MagicTower,
        FireTower,
        CanonTower
    }

    private void OnValidate()
    {
        if (_buildPrice < 0) _buildPrice = 0;
        if (_damage < 0) _damage = 0;
        if (_range < 0) _range = 0.0f;
        if (_shootInterval < 0) _shootInterval = 0.0f;
    }
    
}
